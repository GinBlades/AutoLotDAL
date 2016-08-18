using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.EF;
using AutoLotDAL.Repos;
using AutoLotDAL.Models;
using static System.Console;

namespace AutoLotTestDrive {
    class Program {
        static void Main(string[] args) {
            Database.SetInitializer(new DataInitializer());
            PrintAllInventory();
        }

        private static void PrintAllInventory() {
            using (var repo = new InventoryRepo()) {
                foreach (Inventory c in repo.GetAll()) {
                    WriteLine(c);
                }
            }
        }
    }
}
