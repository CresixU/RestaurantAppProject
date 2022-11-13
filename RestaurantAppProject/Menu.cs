using RestaurantAppProject.Models.Products.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject
{
    public class Menu
    {
        public void Show()
        {
            char key = '?';
            do
            {
                ShowCategories();

                key = Console.ReadKey(true).KeyChar;
            } while (key != 'q');
        }

        private void ShowCategories()
        {
            Console.WriteLine("1 - Foods");
            Console.WriteLine("2 - Drinks");
            Console.WriteLine("3 - Show my information");
            char keyCategory = Console.ReadKey(true).KeyChar;
            switch (keyCategory)
            {
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                    break;
                default:
                    break;
            }
        }
    }
}
