using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebWasted.Areas.Identity.Data;
using WebWasted.Data;

[assembly: HostingStartup(typeof(WebWasted.Areas.Identity.IdentityHostingStartup))]
namespace WebWasted.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebWastedContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebWastedContextConnection")));

                services.AddDefaultIdentity<WebWastedUser>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                
                    .AddEntityFrameworkStores<WebWastedContext>();
            });
        }
    }
}