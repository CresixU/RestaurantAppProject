using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAppProject.Models.Products.Drinks;
using RestaurantAppProject.Models.Products.Foods;

namespace RestaurantAppProject.Services.Drinks
{
    internal class PizzaService
    {
        List<Pizza> Pizzas = new List<Pizza>();

        public void Create(string name, string description, decimal price, List<string> ingredients, PizzaSize size=PizzaSize.medium)
        {
            Pizzas.Add(new Pizza(name,description,price,ingredients,size));
        }

        public void ShowDetails(Pizza food)
        {
            Console.WriteLine($"Name: {food.Name}");
            Console.WriteLine($"Description: {food.Description}");
            Console.WriteLine($"Price: {food.Price}$");
            PrintIngredients(food.Ingredients);
            Console.WriteLine($"Points: {food.RewardsInPoints}");
        }

        public void ShowAll()
        {
            foreach (Pizza item in Pizzas)
            {
                ShowDetails(item);
            }
        }

        public void Remove(Pizza food)
        {
            Pizzas.RemoveAt(Pizzas.IndexOf(food));
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
