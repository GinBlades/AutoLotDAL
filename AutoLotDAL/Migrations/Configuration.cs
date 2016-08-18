namespace AutoLotDAL.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoLotDAL.EF.AutoLotEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AutoLotDAL.EF.AutoLotEntities";
        }

        protected override void Seed(AutoLotDAL.EF.AutoLotEntities context) {
            var customers = new List<Customer> {
                new Customer { FirstName = "Dave", LastName = "Brenner" },
                new Customer { FirstName = "Jeffrey", LastName = "Higgins" },
                new Customer { FirstName = "Bobby", LastName = "Drop Tables" },
                new Customer { FirstName = "Bruce", LastName = "Irving" },
                new Customer { FirstName = "Steve", LastName = "Fox" },
                new Customer { FirstName = "Asuka", LastName = "Kazama" },
                new Customer { FirstName = "DoSan", LastName = "Baek" }
            };
            customers.ForEach(x => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, x));

            var inventory = new List<Inventory> {
                new Inventory { Color = "Brown", Make = "Ford", PetName="Tina" },
                new Inventory { Color = "Blue", Make = "Colt", PetName="Cruiser" },
                new Inventory { Color = "Black", Make = "BMW", PetName="Takk" },
                new Inventory { Color = "Red", Make = "Ford", PetName="Forge" },
                new Inventory { Color = "Green", Make = "Ford", PetName="Contour" }
            };
            inventory.ForEach(x => context.Inventory.AddOrUpdate(i => new { i.Make, i.Color, i.PetName }, x));

            var orders = new List<Order> {
                new Order { Car = inventory[0], Customer = customers[1] },
                new Order { Car = inventory[1], Customer = customers[4] },
                new Order { Car = inventory[2], Customer = customers[2] },
                new Order { Car = inventory[3], Customer = customers[3] },
                new Order { Car = inventory[4], Customer = customers[6] }
            };
            orders.ForEach(x => context.Orders.AddOrUpdate(o => new { o.CarId, o.CustId }, x));

            context.CreditRisks.AddOrUpdate(c => new { c.FirstName, c.LastName },
                new CreditRisk { CustId = customers[2].CustId, FirstName = customers[2].FirstName, LastName = customers[2].LastName });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
