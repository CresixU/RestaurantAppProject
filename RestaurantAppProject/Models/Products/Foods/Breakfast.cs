using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products.Foods
{
    internal class Breakfast : Food
    {
        public Breakfast(string name, string description, decimal price, List<string> ingredients)
            : base(name, description,price,ingredients)
        {

        }
    }
}
