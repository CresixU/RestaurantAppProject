using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products
{
    public abstract class Drink : Product
    {
        public int Capacity { get; set; }

        public Drink(string name, string description, decimal price, int capacity)
            : base(name, description, price)
        {
            Capacity = capacity;
        }

    }
}
