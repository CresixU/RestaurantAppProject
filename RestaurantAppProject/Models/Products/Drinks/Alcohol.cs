using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products.Drinks
{
    internal class Alcohol : Drink
    {
        public Alcohol(string name, string description, decimal price, int capacity, decimal vol)
            : base(name, description, price, capacity)
        {
            AlcoholVolume = vol;
        }
    }
}
