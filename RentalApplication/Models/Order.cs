using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalApplication.Models
{
    public class Order
    {
        public Order()
        {

        }

        private const double _tax = 8;

        public Vehicle Vehicle { get; set; } // must-have
        public Helmet Helmet { get; set; } // optional
        public int Days { get; set; }

        public string TotalPriceStr
        {
            get
            {
                return $"Total before tax: ${CalculatePrice(false)}\nOrder total: ${CalculatePrice()}";
            }
        }

        public double CalculatePrice(bool withTax = true)
        {
            double price = 0;
            for (int i = 0; i < this.Days; i++)
            {
                price += this?.Vehicle?.Price ?? 0;
                price += this?.Helmet?.Price ?? 0;
            }

            if (withTax)
            {
                price += price / 100 * _tax;
            }
 
            return price;
        }
    }
}
