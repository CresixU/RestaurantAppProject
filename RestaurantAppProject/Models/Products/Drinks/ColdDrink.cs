using Spectre.Console;

namespace RestaurantAppProject.Models.Products.Drinks
{
    internal class ColdDrink : Drink
    {
        public ColdDrink(string name, string description, decimal price, int capacity)
            : base(name, description, price, capacity)
        {
        }
        public override void ShowDetails(Table table)
        {
            table.AddRow($"{Id}", $"{Name}", $"{Price}", $"{Description}", $"{Capacity + "ml"}", "");
        }

        public static void Create(List<Drink> list, string name, string description, decimal price, int capacity)
        {
            list.Add(new ColdDrink(name, description, price, capacity));
        }

        public override void Delete(List<Drink> list)
        {
            Drink item = this;
            list.Remove(item);
        }
    }
}
