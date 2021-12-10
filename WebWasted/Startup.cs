using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading;
using System.Threading.Tasks;
//using WebWasted.Dummy;
using WebWasted.Timers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.IO;
using WebWasted.Hubs;
using WebWasted.Services;
using WebWasted.Middleware;


namespace WebWasted
{
    public class Startup
    {
        private Timer foodExpiryTimer;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable Cross-origin reasource sharing
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
               .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            services.AddControllers();

            //services.AddDbContext<DataContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            
            services.AddSingleton<IDataContext, DataContext>();

            services.AddSingleton<IItemService, ItemService>();
            
            services.AddSingleton<IUserService, UserService>();

            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<LoggingMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/ChatHub");
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
                RequestPath = "/Photos"
            });

            var autoEvent = new AutoResetEvent(false);
            var foodExpiryTimer = new FoodExpiryTimer(new DataContext());
            this.foodExpiryTimer = new Timer(foodExpiryTimer.RemoveExpiredFood,
                                       autoEvent, 15000, 20 * 1000);
        }
    }
}
