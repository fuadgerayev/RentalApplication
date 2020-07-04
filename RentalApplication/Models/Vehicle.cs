using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalApplication.Models
{
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public string FullName
        {
            get
            {
                return ($"{Make} {Model}");
            }
        }

        public override string ToString()
        {
            return FullName + "\t" + "$" + Price;
        }
    }
}
