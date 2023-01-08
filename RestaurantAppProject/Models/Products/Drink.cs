
namespace RestaurantAppProject.Models.Products
{
    public class Drink : Product
    {
        public int Capacity { get; set; }

        public Drink(string name, string description, decimal price, int capacity)
            : base(name, description, price)
        {
            Capacity = capacity;
        }
        public virtual void Delete(List<Drink> list)
        {
            throw new NotImplementedException();
        }

    }
}
