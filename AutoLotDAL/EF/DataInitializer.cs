using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.EF {
    public class DataInitializer : DropCreateDatabaseAlways<AutoLotEntities> {
        protected override void Seed(AutoLotEntities context) {
            var customers = new List<Customer> {
                new Customer { FirstName = "Dave", LastName = "Brenner" },
                new Customer { FirstName = "Jeffrey", LastName = "Higgins" },
                new Customer { FirstName = "Bobby", LastName = "Drop Tables" },
                new Customer { FirstName = "Bruce", LastName = "Irving" },
                new Customer { FirstName = "Steve", LastName = "Fox" },
                new Customer { FirstName = "Asuka", LastName = "Kazama" },
                new Customer { FirstName = "DoSan", LastName = "Baek" }
            };
            customers.ForEach(x => context.Customers.Add(x));

            var inventory = new List<Inventory> {
                new Inventory { Color = "Brown", Make = "Ford", PetName="Tina" },
                new Inventory { Color = "Blue", Make = "Colt", PetName="Cruiser" },
                new Inventory { Color = "Black", Make = "BMW", PetName="Takk" },
                new Inventory { Color = "Red", Make = "Ford", PetName="Forge" },
                new Inventory { Color = "Green", Make = "Ford", PetName="Contour" }
            };
            inventory.ForEach(x => context.Inventory.Add(x));

            var orders = new List<Order> {
                new Order { Car = inventory[0], Customer = customers[1] },
                new Order { Car = inventory[1], Customer = customers[4] },
                new Order { Car = inventory[2], Customer = customers[2] },
                new Order { Car = inventory[3], Customer = customers[3] },
                new Order { Car = inventory[4], Customer = customers[6] }
            };
            orders.ForEach(x => context.Orders.Add(x));

            var creditRisks = new List<CreditRisk> {
                new CreditRisk { CustId = customers[2].CustId, FirstName = customers[2].FirstName, LastName = customers[2].LastName }
            };
            creditRisks.ForEach(x => context.CreditRisks.Add(x));
            context.SaveChanges();
            //base.Seed(context);
        }

    }
}
