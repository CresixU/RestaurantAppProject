using RestaurantAppProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RewardsInPoints { get; set; }

        public Product(string name, string description, decimal price)
        {
            Id = ProductService.ProductId++;
            Name = name;
            Description = description;
            Price = price;
            RewardsInPoints = (int)Price;
        }

        public virtual void ShowDetails()
        {
            throw new NotImplementedException();
        }
        public virtual void Delete(List<Drink> list)
        {
            throw new NotImplementedException();
        }

    }

}
