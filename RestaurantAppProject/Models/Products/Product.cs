using RestaurantAppProject.Services;
using Spectre.Console;

namespace RestaurantAppProject.Models.Products
{
    public abstract class Product
    {
        public int Id { get; }
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

        public virtual void ShowDetails(Table table)
        {
            throw new NotImplementedException();
        }

    }

}
