using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products
{
    public abstract class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RewardsInPoints { get; set; }

        public Item(string name, string description, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            RewardsInPoints = (int)Price;
        }
    }
}
