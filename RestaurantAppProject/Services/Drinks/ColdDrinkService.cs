using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAppProject.Models.Products.Drinks;

namespace RestaurantAppProject.Services.Drinks
{
    internal class ColdDrinkService
    {
        List<ColdDrink> ColdDrinks = new List<ColdDrink>();

        public void Create(string name, string description, decimal price, int capacity, decimal vol = 0)
        {
            ColdDrinks.Add(new ColdDrink(name, description, price, capacity));
        }

        public void ShowDetails(ColdDrink drink)
        {
            Console.WriteLine($"Name: {drink.Name}");
            Console.WriteLine($"Description: {drink.Description}");
            Console.WriteLine($"Price: {drink.Price}$");
            Console.WriteLine($"Points: {drink.RewardsInPoints}");
            Console.WriteLine($"Capacity: {drink.Capacity} ml");
        }

        public void ShowAll()
        {
            foreach (ColdDrink item in ColdDrinks)
            {
                ShowDetails(item);
            }
        }

        public void Remove(ColdDrink drink)
        {
            ColdDrinks.RemoveAt(ColdDrinks.IndexOf(drink));
        }
    }

}
