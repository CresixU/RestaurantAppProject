using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products;

namespace RestaurantAppProject.Models
{
    internal class Order
    {
        public Guid Id { get; set; }
        public List<Item> Items = new List<Item>();
        public DateTime OrderTime { get; set; }
        public decimal Price { get; set; }
        public Person? Owner { get; set; }

        public Order(List<Item> items, decimal price, Person owner)
        {
            Id = Guid.NewGuid();
            Items = items;
            OrderTime = DateTime.Now;
            Price = price;
            Owner = owner;
        }
    }
}
