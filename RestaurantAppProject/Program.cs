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
            ApplicationSeeder seeder = new ApplicationSeeder(productService, orderService, personService);
            seeder.Seed();
            //DataManager.LoadData(productService.Drinks, productService.Foods, orderService.Orders, personService.People);

            foreach(var item in productService.Drinks)
            {
                Console.WriteLine(item.Id);
            }
            Console.WriteLine("hi");
            //DataManager.SaveData(productService.Drinks, productService.Foods, orderService.Orders, personService.People);
        }
    }
}