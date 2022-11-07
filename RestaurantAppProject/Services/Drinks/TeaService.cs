using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAppProject.Models.Products;

namespace RestaurantAppProject.Services.Drinks
{
    internal class TeaService
    {
        List<Tea> Teas = new List<Tea>();

        public void Create(string name, string description, decimal price, int capacity, TeaType type)
        {
            Teas.Add(new Tea(name, description, price, capacity, type));
        }

        public void ShowDetails(Tea tea)
        {
            Console.WriteLine($"Name: {tea.Name}");
            Console.WriteLine($"Description: {tea.Description}");
            Console.WriteLine($"Price: {tea.Price}$");
            Console.WriteLine($"Points: {tea.RewardsInPoints}");
            Console.WriteLine($"Capacity: {tea.Capacity} ml");
        }

        public void ShowAll()
        {
            foreach (Tea item in Teas)
            {
                ShowDetails(item);
            }
        }

        public void Remove(Tea tea)
        {
            Teas.RemoveAt(Teas.IndexOf(tea));
        }
    }

}
