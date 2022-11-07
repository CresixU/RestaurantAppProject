using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAppProject.Models.Products.Drinks;
using RestaurantAppProject.Models.Products.Foods;

namespace RestaurantAppProject.Services.Food
{
    internal class SoupService
    {
        List<Soup> Soups = new List<Soup>();

        public void Create(string name, string description, decimal price, List<string> ingredients)
        {
            Soups.Add(new Soup(name,description,price,ingredients));
        }

        public void ShowDetails(Soup food)
        {
            Console.WriteLine($"Name: {food.Name}");
            Console.WriteLine($"Description: {food.Description}");
            Console.WriteLine($"Price: {food.Price}$");
            PrintIngredients(food.Ingredients);
            Console.WriteLine($"Points: {food.RewardsInPoints}");
        }

        public void ShowAll()
        {
            foreach (Soup item in Soups)
            {
                ShowDetails(item);
            }
        }

        public void Remove(Soup food)
        {
            Soups.RemoveAt(Soups.IndexOf(food));
        }

        private void PrintIngredients(List<string>? list)
        {
            Console.Write("Ingredients: ");
            if (list is null || !list.Any())
            {
                Console.Write("None");
                return;
            }
            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
        }
    }

}
