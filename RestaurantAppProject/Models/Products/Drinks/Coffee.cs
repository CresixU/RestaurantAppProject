﻿using RestaurantAppProject.Interfaces;
using Spectre.Console;

namespace RestaurantAppProject.Models.Products.Drinks
{
    internal class Coffee : Drink, IDrinkable
    {

        public Coffee(string name, string description, decimal price, int capacity)
            : base(name, description, price, capacity)
        {
        }

        public override void ShowDetails(Table table)
        {
            table.AddRow($"{Id}", $"{Name}", $"{Price}", $"{Description}", $"{Capacity + "ml"}", "");
        }

        public static void Create(List<Drink> list, string name, string description, decimal price, int capacity)
        {
            list.Add(new Coffee(name, description, price, capacity));
        }

        public override void Delete(List<Drink> list)
        {
            var item = this;
            list.Remove(item);
        }
    }

}
