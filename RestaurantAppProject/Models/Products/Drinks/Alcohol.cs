using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products.Drinks
{
    internal class Alcohol : Drink
    {
        public decimal AlcoholVolume { get; set; }

        public Alcohol(string name, string description, decimal price, int capacity, decimal vol)
            : base(name, description, price, capacity)
        {
            AlcoholVolume = vol;
        }


        public override void ShowDetails(Table table)
        {
            table.AddRow($"{Id}",$"{Name}", $"{Price}", $"{Description}", $"{Capacity + "ml"}", $"{AlcoholVolume}%");
        }

        public static void Create(List<Drink> list,string name, string description, decimal price, int capacity, decimal vol)
        {
            list.Add(new Alcohol(name,description,price,capacity, vol));
        }

        public override void Delete(List<Drink> list)
        {
            Drink item = this;
            list.Remove(item);
        }
    }
}
