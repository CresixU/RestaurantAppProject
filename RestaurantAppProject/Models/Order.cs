using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products;
using RestaurantAppProject.Services;

namespace RestaurantAppProject.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public List<int> Items = new List<int>();
        public DateTime OrderTime { get; set; }
        public decimal Price { get; set; }
        public int OwnerId { get; set; }

        public Order(List<int> items, decimal price, int ownerId)
        {
            Id = OrderService.OrderId++;
            Items = items;
            OrderTime = DateTime.Now;
            Price = price;
            OwnerId = ownerId;
        }
    }
}
