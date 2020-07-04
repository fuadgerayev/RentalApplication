using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalApplication.Models
{
    public class Helmet
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public Helmet(string Brand, string Model, double Price)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Price = Price;
        }

        public override string ToString()
        {
            return $"{Brand} {Model}\t${Price}";
        }
    }
}
