using RestaurantAppProject.Services;
using RestaurantAppProject.Tools;
using RestaurantAppProject.Views;

namespace RestaurantAppProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.WindowWidth = 200, (int)(Console.WindowHeight = 40));

            ProductService productService = new ProductService();
            PersonService personService = new PersonService();
            OrderService orderService = new OrderService();
            DataManager dataManager = new DataManager();

            var list = dataManager.LoadData(productService.Drinks, productService.Foods, orderService.Orders, personService.People);

            productService.Drinks = (List<Models.Products.Drink>)list[0];
            productService.Foods = (List<Models.Products.Food>)list[1];
            orderService.Orders = (List<Models.Order>)list[2];
            personService.People = (List<Models.People.Person>)list[3];

            ApplicationSeeder seeder = new ApplicationSeeder(productService, orderService, personService);
            seeder.Seed();
            MainView menu = new MainView(productService, personService, orderService, dataManager);
            menu.Show();
           


            dataManager.SaveData(productService.Drinks, productService.Foods, orderService.Orders, personService.People);
        }
    }
}