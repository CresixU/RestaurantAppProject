using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products.Drinks
{
    internal class Coffee : Drink
    {
        public Coffee(string name, string description, decimal price, int capacity)
            : base(name, description, price, capacity)
        {
        }
    }
}
