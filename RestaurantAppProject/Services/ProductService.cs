using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products;
using RestaurantAppProject.Tools;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Services
{
    public class ProductService
    {
        public List<Drink> Drinks { get; set; }
        public List<Food> Foods { get; set; }

        public static int ProductId { get; set; }

        public ProductService()
        {
            Drinks = new List<Drink>();
            Foods = new List<Food>();
            ProductId = 1;
        }

        public static void ShowFood(List<Food> foods)
        {
            Console.Clear();
            var table = new Table();
            table.Border(TableBorder.SimpleHeavy).BorderStyle("yellow");
            table.AddColumn(new TableColumn("[bold yellow]ID[/]").Centered());
            table.AddColumn(new TableColumn("[bold yellow]Name[/]").Centered());
            table.AddColumn(new TableColumn("[bold yellow]Price[/]").Centered());
            table.AddColumn(new TableColumn("[bold yellow]Description[/]").Centered().Width(70));
            table.AddColumn(new TableColumn("[bold yellow]Ingrediens[/]").Centered());
            table.AddColumn(new TableColumn("[bold yellow]Additional[/]").Centered());
            foreach (var food in foods)
            {
                food.ShowDetails(table);
            }
            AnsiConsole.Write(table);
        }
        
        public static void ShowDrink(List<Drink> drinks)
        {
            Console.Clear();
            var table = new Table();
            table.Border(TableBorder.SimpleHeavy).BorderStyle("yellow");
            table.AddColumn(new TableColumn("[bold yellow]ID[/]").Centered());
            table.AddColumn(new TableColumn("[bold yellow]Name[/]").Centered());
            table.AddColumn(new TableColumn("[bold yellow]Price[/]").Centered());
            table.AddColumn(new TableColumn("[bold yellow]Description[/]").Centered().Width(70));
            table.AddColumn(new TableColumn("[bold yellow]Capacity[/]").Centered());
            table.AddColumn(new TableColumn("[bold yellow]Additional[/]").Centered());

            foreach (var drink in drinks)
            {
                drink.ShowDetails(table);
            }
            AnsiConsole.Write(table);
        }

        public static void AddToBasket(Product product, Client client)
        {
            client.Basket.Add(product);
        }


    }
}
