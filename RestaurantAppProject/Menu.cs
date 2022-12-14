using RestaurantAppProject.Exceptions;
using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products.Foods;
using RestaurantAppProject.Services;
using RestaurantAppProject.Tools;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject
{
    public class Menu
    {
        public Menu(ProductService productService,PersonService personService, OrderService orderService)
        {
            _productService = productService;
            _personService = personService;
            _orderService = orderService;
        }
        Person? loggedPerson = null;
        private readonly ProductService _productService;
        private readonly PersonService _personService;
        private readonly OrderService _orderService;

        public void Show()
        {
            while(true)
            {
                if (loggedPerson is null) ShowMenuGuest();
                if (loggedPerson != null) ShowCategories();
            }
        }

        private void ShowCategories()
        {
            while(true)
            {
                Console.Clear();
                var grid = new Grid();
                grid.AddColumn();
                grid.AddColumn();

                grid.AddRow(new string[] { "Number", "Option" });
                grid.AddRow(new string[] { "[yellow1]  1[/]", "Food" });
                grid.AddRow(new string[] { "[yellow1]  2[/]", "Drinks" });
                grid.AddRow(new string[] { "[yellow1]  3[/]", "Show my information" });
                grid.AddRow(new string[] { "[yellow1]  4[/]", "Show my order's history" });
                if (loggedPerson != null && loggedPerson.Basket.Any())
                    grid.AddRow(new string[] { "[yellow1]  P[/]", "Make an order" });
                grid.AddRow(new string[] { "[yellow1]  Q[/]", "Exit" });

                AnsiConsole.Write(grid);
                char keyCategory = Console.ReadKey(true).KeyChar;
                switch (keyCategory)
                {
                    case '1':
                        ProductService.ShowFood(_productService.Foods);
                        AddToBasketOrSkip("food");
                        break;
                    case '2':
                        ProductService.ShowDrink(_productService.Drinks);
                        AddToBasketOrSkip("drink");
                        break;
                    case '3':
                        loggedPerson.ShowDetails();
                        break;
                    case '4':
                        _orderService.OrdersHistory(_productService, loggedPerson);
                        break;
                    case 'p':
                        if (loggedPerson.Basket.Any()) Pay();
                        break;
                    case 'q':
                        loggedPerson = null;
                        return;
                    default:
                        break;
                }
                Console.ReadKey(true);
                Console.Clear();
            }

        }
        private void ShowMenuGuest()
        {
            do
            {
                Console.Clear();
                var grid = new Grid();
                grid.AddColumn();
                grid.AddColumn();

                grid.AddRow(new string[] { "Number", "Option" });
                grid.AddRow(new string[] { "[yellow1]  1[/]", "Log in"});
                grid.AddRow(new string[] { "[yellow1]  2[/]", "Create Account" });
                grid.AddRow(new string[] { "[yellow1]  Q[/]", "Exit" });

                AnsiConsole.Write(grid);
                char keyCategory = Console.ReadKey(true).KeyChar;
                switch (keyCategory)
                {
                    case '1':
                        loggedPerson = LogIn();
                        break;
                    case '2':
                        SingUp();
                        break;
                    case 'q':
                        Environment.Exit(0);
                        return;
                    default:
                        break;
                }
            } while (loggedPerson is null);
        }

        private Person LogIn()
        {
            var mail = Validator.String("[yellow]Insert your Email: [/]", 5, 25);
            var person = _personService.People.FirstOrDefault(p => p.Email == mail);
            if (person is null)
            {
                AnsiConsole.Markup("[red]Person with this email was not found[/]");
                Console.ReadKey();
                return null;
            }
            return person;
        }

        private void SingUp()
        {
            _personService.People.Add(new Client(
            
                Validator.String("Insert your Name: ", 3, 25),
                Validator.String("Insert your Surname: ", 3, 50),
                Validator.Date("Insert your birthdate (dd.mm.yyyy): "),
                Validator.String("Insert your Email: ", 7, 50),
                Validator.Password()
            ));
            AnsiConsole.Markup("[green]Account succesfully created[/]");
        }

        private void AddToBasketOrSkip(string category)
        {
            string choice = Validator.String("\nIf you want add somethig to basket, write it's [yellow]number[/] or press [yellow]'Q'[/]:");
            if (choice.ToUpper().StartsWith("Q")) return;
            if(category == "food")
            {
                var product = _productService.Foods.FirstOrDefault(f => f.Id.ToString() == choice);
                if (product is null)
                {
                    AnsiConsole.Markup("[red]Product not found[red]");
                    return;
                }

                loggedPerson.Basket.Add(product);
                AnsiConsole.Markup($"[yellow]{product.Name}[/][green] for [/][yellow]{product.Price}$[/][green] has been added to your basket[/]");
            }
            else if (category == "drink")
            {
                var product = _productService.Drinks.FirstOrDefault(f => f.Id.ToString() == choice);
                if (product is null)
                {
                    AnsiConsole.Markup("[red]Product not found[red]");
                    return;
                }

                loggedPerson.Basket.Add(product);
                AnsiConsole.Markup($"[yellow]{product.Name}[/][green] for [/][yellow]{product.Price}$[/][green] has been added to your basket[/]");
            }
            else AnsiConsole.Markup("[red]Something went wrong with categories [/]");
            
        }

        private void Pay()
        {
            if (loggedPerson.Basket is null)
            {
                AnsiConsole.Markup("[red]Basket is empty[/]");
                return;
            }
            if (!AnsiConsole.Confirm("\n[yellow]Do you want to pay now? [/]\n")) return;


            AnsiConsole.Markup("[green]Payment succes[/]");

            var personBasket = loggedPerson
                                .Basket.Select(p => p.Id)
                                .ToList<int>();

            var personPrice = loggedPerson
                                .Basket
                                .Sum(p => p.Price);

            _orderService.Create
                (
                    personBasket,
                    personPrice,
                    loggedPerson.Id
                );
            loggedPerson.Basket.Clear();
            AnsiConsole.Markup($"\n\n[yellow]Your order's number is[/][green] {_orderService.Orders.FindLast(o => o.OwnerId == loggedPerson.Id).Id}[/][yellow] [/]");

            loggedPerson.Points += (int)personPrice;
            AnsiConsole.Markup($"\n\n[yellow]You recived[/][green] {(int)personPrice}[/][yellow] points for this order[/]");

        }

    }
}
