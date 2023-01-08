using Spectre.Console;

namespace RestaurantAppProject.Models.Products.Foods
{
    internal class Dessert : Food
    {
        public Dessert(string name, string description, decimal price, List<string> ingredients)
            : base(name, description, price, ingredients)
        {

        }

        public override void ShowDetails(Table table)
        {
            table.AddRow($"{Id}", $"{Name}", $"{Price}", $"{Description}", $"{ShowIngrediens()}", "");
        }

        public static void Create(List<Food> list, string name, string description, decimal price, List<string> ingredients)
        {
            list.Add(new Dessert(name, description, price, ingredients));
        }

        public override void Delete(List<Food> list)
        {
            var item = this;
            list.Remove(item);
        }
    }
}
