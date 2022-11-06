using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products.Drinks
{
    internal class CoffeeService
    {
        List<Coffee> Coffees = new List<Coffee>();

        public void Create(string name, string description, decimal price, int capacity, decimal vol=0)
        {
            Coffees.Add(new Coffee(name, description, price, capacity));
        }

        public void ShowDetails(Coffee drink)
        {
            Console.WriteLine($"Name: {drink.Name}");
            Console.WriteLine($"Description: {drink.Description}");
            Console.WriteLine($"Price: {drink.Price}$");
            Console.WriteLine($"Points: {drink.RewardsInPoints}");
            Console.WriteLine($"Capacity: {drink.Capacity} ml");
        }

        public void ShowAll()
        {
            foreach (Coffee item in Coffees)
            {
                ShowDetails(item);
            }
        }

        public void Remove(Coffee item)
        {
            Coffees.RemoveAt(Coffees.IndexOf(item));
        }
    }

}
