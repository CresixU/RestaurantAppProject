using RestaurantAppProject.Models.Products.Drinks;
using Spectre.Console;
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

        public override void ShowDetails(Table table)
        {
            table.AddRow($"{Id}", $"{Name}", $"{Price}", $"{Description}", $"{ShowIngrediens()}", "");
        }

        public static void Create(List<Food> list, string name, string description, decimal price, List<string> ingredients)
        {
            list.Add(new Breakfast(name, description, price, ingredients));
        }

        public override void Delete(List<Food> list)
        {
            var item = this;
            list.Remove(item);
        }

    }
}
