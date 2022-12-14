using Spectre.Console;
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

        public override void ShowDetails(Table table)
        {
            table.AddRow($"{Id}", $"{Name}", $"{Price}", $"{Description}", $"{ShowIngrediens()}", $"{Size}");
        }

        public static void Create(List<Food> list, string name, string description, decimal price, List<string> ingredients, PizzaSize size)
        {
            list.Add(new Pizza(name, description, price, ingredients, size));
        }

        public override void Delete(List<Food> list)
        {
            var item = this;
            list.Remove(item);
        }
    }

    enum PizzaSize
    {
        small = 25,
        medium = 35,
        large = 45
    }
}
