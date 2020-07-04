using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalApplication.Models
{
    public class Bicycle : Vehicle
    {
        public BikeSizes Size { get; set; }

        public override string ToString()
        {
            return $"{FullName} ({Size.ToString()})\t{Price}$";
        }
    }
}
