using RestaurantAppProject.Models.People;
using RestaurantAppProject.Services;
using RestaurantAppProject.Tools;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Views
{
    public class ClientView
    {
        public ClientView(Person person,ProductService productService, PersonService personService, OrderService orderService, DataManager dataManager)
        {
            _productService = productService;
            _personService = personService;
            _orderService = orderService;
            _dataManager = dataManager;
            loggedPerson = person;
        }
        Person? loggedPerson;
        private readonly ProductService _productService;
        private readonly PersonService _personService;
        private readonly OrderService _orderService;
        private readonly DataManager _dataManager;

        public void AddToBasketOrSkip(string category)
        {
            string choice = Validator.String("\nIf you want add somethig to basket, write it's [yellow]number[/] or press [yellow]'Q' to back[/]:");
            if (choice.ToUpper().StartsWith("Q")) return;
            if (category == "food")
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

        public void Pay()
        {
            if (loggedPerson.Basket is null)
            {
                AnsiConsole.Markup("[red]\nBasket is empty[/]");
                return;
            }


            var costs = _personService.CalculateBasket(loggedPerson);
            if (loggedPerson.Email.Contains("@local"))
            {
                costs = Math.Round(costs * 0.75m,2);
            }
            if (loggedPerson.Balance < costs)
            {
                AnsiConsole.Markup($"[red]\nYou don't have enough money [/]({costs}$)[red] in your wallet.[/]");
                return;
            }
                
            AnsiConsole.Markup($"\n[yellow]Total costs [/]{costs}$[yellow].[/]");
            if (loggedPerson.Email.Contains("@local")) AnsiConsole.Markup("[green] -25% employee discount[/] ");

            if (!AnsiConsole.Confirm("\n[yellow]\nDo you want to pay now? [/]\n")) return;

            if (loggedPerson.Points > 0)
            {
                decimal discount = loggedPerson.Points / 10;
                if (discount >= costs) discount = costs;
                if (AnsiConsole.Confirm($"\n[yellow]Do you want to use your points as discount[/](-{discount}$)[yellow] in this order?[/]"))
                {
                    loggedPerson.Points -= (int)discount;
                    AnsiConsole.Markup("[green]Discount Activated[/]");
                }
            }

            var personBasket = loggedPerson.Basket.Select(p => p.Id).ToList();

            var personPrice = _personService.CalculateBasket(loggedPerson);

            _orderService.Create
                (
                    personBasket,
                    personPrice,
                    loggedPerson.Id
                );

            loggedPerson.Balance -= costs;
            AnsiConsole.Markup("[green]\nPayment succes[/]");

            loggedPerson.Basket.Clear();
            AnsiConsole.Markup($"\n\n[yellow]Your order's number is[/][green] {_orderService.Orders.FindLast(o => o.OwnerId == loggedPerson.Id).Id}[/][yellow]. [/]");

            loggedPerson.Points += (int)personPrice;
            AnsiConsole.Markup($"\n\n[yellow]You recived[/][green] {(int)personPrice}[/][yellow] points for this order[/]");
        }
    }
}
