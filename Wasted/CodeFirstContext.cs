using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace Wasted
{
    class CodeFirstContext : DbContext
    {
        public CodeFirstContext() : base()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CodeFirstContext>());
        }


        //https://www.c-sharpcorner.com/article/create-a-new-database-using-code-first-in-entity-framework/
        //<Foodlist> ar <Food>  ???
        public DbSet <Food> Foods { get; set; }


        //susirast form1 koda ir susitvarkyt su viskuo
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Set values into company model.  
 //           Food objFood = new Food();
 //           objFood.FoodName = txtFoodName.Text;
 //           objFood.FoodDescription = txtFoodDescription.Text;

            // Create context object and then save company data.  
            CodeFirstContext objContext = new CodeFirstContext();
//            objContext.Foods.Add(objFood);
            objContext.SaveChanges();

        }


    }
}
