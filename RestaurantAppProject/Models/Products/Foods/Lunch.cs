﻿using RestaurantAppProject.Interfaces;
using Spectre.Console;

namespace RestaurantAppProject.Models.Products.Foods
{
    internal class Lunch : Food, IEatable
    {
        public Lunch(string name, string description, decimal price, List<string> ingredients)
            : base(name, description, price, ingredients)
        {

        }

        public override void ShowDetails(Table table)
        {
            table.AddRow($"{Id}", $"{Name}", $"{Price}", $"{Description}", $"{ShowIngrediens()}", "");
        }

        public static void Create(List<Food> list, string name, string description, decimal price, List<string> ingredients)
        {
            list.Add(new Lunch(name, description, price, ingredients));
        }

        public override void Delete(List<Food> list)
        {
            var item = this;
            list.Remove(item);
        }
    }
}
