using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products.Drinks
{
    internal class AlcoholService
    {
        List<Alcohol> Alcohols = new List<Alcohol>();

        public void Create(string name, string description, decimal price, int capacity, decimal vol)
        {
            Alcohols.Add(new Alcohol(name, description, price, capacity, vol));
        }

        public void ShowDetails(Alcohol drink)
        {
            Console.WriteLine($"Name: {drink.Name}");
            Console.WriteLine($"Description: {drink.Description}");
            Console.WriteLine($"Price: {drink.Price}$");
            Console.WriteLine($"Points: {drink.RewardsInPoints}");
            Console.WriteLine($"Capacity: {drink.Capacity} ml");
            Console.WriteLine($"Vol/Alc: {drink.AlcoholVolume} %");
        }

        public void ShowAll()
        {
            foreach (Alcohol item in Alcohols)
            {
                ShowDetails(item);
            }
        }

        public void Remove(Alcohol drink)
        {
            Alcohols.RemoveAt(Alcohols.IndexOf(drink));
        }
    }

}
