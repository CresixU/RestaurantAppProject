using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products.Foods
{
    internal class Pizza : Food
    {
        public int Size { get; set; }

        public Pizza(string name, string description, decimal price, List<string> ingredients, PizzaSize size)
            : base(name, description, price, ingredients)
        {
            Size = (int)size;
        }
    }

    enum PizzaSize
    {
        small = 25,
        medium = 35,
        large = 45
    }
}
