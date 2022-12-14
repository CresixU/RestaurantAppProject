﻿using RestaurantAppProject.Models.Products.Drinks;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products
{
    internal class Tea : Drink
    {
        public TeaType Type { get; set; }

        public Tea(string name, string description, decimal price, int capacity,TeaType type)
            : base(name, description, price, capacity)
        {
            Type = type;
        }
        public override void ShowDetails(Table table)
        {
            table.AddRow($"{Id}", $"{Name}", $"{Price}", $"{Description}", $"{Capacity + "ml"}", $"{Type}");
        }

        public static void Create(List<Drink> list, string name, string description, decimal price, int capacity, TeaType type)
        {
            list.Add(new Tea(name, description, price, capacity, type));
        }

        public override void Delete(List<Drink> list)
        {
            Drink item = this;
            list.Remove(item);
        }


    }

    enum TeaType
    {
        Black,
        Green,
        Herbal,
        White,
        Oolong,
        Rooibos
    }
}
