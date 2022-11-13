using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products.Drinks
{
    internal class Coffee : Drink
    {

        public Coffee(string name, string description, decimal price, int capacity)
            : base(name, description, price, capacity)
        {
        }

        public override void ShowDetails()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);
            Console.WriteLine(Price + "$");
            Console.WriteLine(Capacity + "ml");
        }

        public static void Create(List<Drink> list, string name, string description, decimal price, int capacity)
        {
            list.Add(new Coffee(name, description, price, capacity));
        }

        public override void Delete(List<Drink> list)
        {
            Drink item = this;
            list.Remove(item);
        }
    }

}
