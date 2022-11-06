using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products;

namespace RestaurantAppProject.Models
{
    internal class Order
    {
        public Guid Id { get; set; }
        public Person Owner { get; set; }
        public List<Item> items = new List<Item>();
        public DateTime OrderTime { get; set; }
        public decimal Price { get; set; }
    }
}
