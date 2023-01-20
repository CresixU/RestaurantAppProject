
namespace RestaurantAppProject.Models.Products
{
    public class Food : Product
    {
        public List<string>? Ingredients { get;}

        public Food(string name, string description, decimal price, List<string> ingredients)
            : base(name,description,price)
        {
            Ingredients = ingredients;
        }
        public virtual void Delete(List<Food> list)
        {
            throw new NotImplementedException();
        }


        protected string ShowIngrediens() => String.Join(',', Ingredients);
    }
}
