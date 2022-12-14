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
            Console.WriteLine(personService.People[0].Email);
            Menu menu = new Menu(productService, personService, orderService);
            menu.Show();
            //DataManager.LoadData(productService.Drinks, productService.Foods, orderService.Orders, personService.People);


            //DataManager.SaveData(productService.Drinks, productService.Foods, orderService.Orders, personService.People);
        }
    }
}