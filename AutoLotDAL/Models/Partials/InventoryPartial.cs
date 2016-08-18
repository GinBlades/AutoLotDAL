using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.Models {
    public partial class Inventory {
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";

        public override string ToString() {
            return $"{this.PetName ?? "**No Name**"} is a {this.Color} {this.Make} with ID {this.CarId}.";
        }
    }
}
