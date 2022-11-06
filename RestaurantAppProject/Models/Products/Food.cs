using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products
{
    internal class Food : Item
    {
        public List<string>? Ingredients { get; set; }

        public Food(string name, string description, decimal price, List<string> ingredients)
            : base(name,description,price)
        {
            Ingredients = ingredients;
        }
    }
}
