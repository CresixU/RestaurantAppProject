using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products
{
    public abstract class Drink : Item
    {
        public int Capacity { get; set; }
        public decimal AlcoholVolume { get; set; }

        public Drink(string name, string description, decimal price, int capacity,decimal alcoholVolume=0.0M)
            : base(name, description, price)
        {
            Capacity = capacity;
            AlcoholVolume = alcoholVolume;
        }
    }
}
