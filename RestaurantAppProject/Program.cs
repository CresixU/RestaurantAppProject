using RestaurantAppProject.Models.Products.Drinks;
using RestaurantAppProject.Services;
using RestaurantAppProject.Tools;

namespace RestaurantAppProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            PersonService personService = new PersonService();
            OrderService orderService = new OrderService();
            DataManager.LoadData(productService.Drinks, productService.Foods, orderService.Orders, personService.People);
            var alcohol = new Alcohol("Wódka", "Czysta polska", 20.00M, 700, 40.00M);
            var coffee = new Coffee("Kawa", "Opis", 7.99M, 500);
            productService.Drinks.Add(alcohol);
            productService.Drinks.Add(coffee);

            foreach(var item in productService.Drinks)
            {
                Console.WriteLine(item.Id);
            }

            DataManager.SaveData(productService.Drinks, productService.Foods, orderService.Orders, personService.People);
        }
    }
}