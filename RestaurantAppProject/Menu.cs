using RestaurantAppProject.Models.People;
using RestaurantAppProject.Services;
using RestaurantAppProject.Tools;
using Spectre.Console;

namespace RestaurantAppProject
{
    public class Menu
    {
        public Menu(ProductService productService,PersonService personService, OrderService orderService, DataManager dataManager)
        {
            _productService = productService;
            _personService = personService;
            _orderService = orderService;
            _dataManager = dataManager;
        }
        Person? loggedPerson = null;
        private readonly ProductService _productService;
        private readonly PersonService _personService;
        private readonly OrderService _orderService;
        private readonly DataManager _dataManager;

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
                grid.AddEmptyRow();
                grid.AddRow(new string[] { "[yellow1]  3[/]", "Show my information" });
                grid.AddRow(new string[] { "[yellow1]  4[/]", "Add founds to my wallet" });
                grid.AddRow(new string[] { "[yellow1]  5[/]", "Show my order's history" });
                grid.AddRow(new string[] { "[yellow1]  6[/]", "Change personal data" });
                grid.AddEmptyRow();
                if (loggedPerson != null && loggedPerson.Basket.Any())
                {
                    grid.AddRow(new string[] { "[yellow1]  P[/]", "Make an order" });
                    grid.AddRow(new string[] { "[yellow1]  C[/]", "Clear my basket" });
                    grid.AddEmptyRow();
                }
                grid.AddRow(new string[] { "[yellow1]  Q[/]", "Exit" });

                AnsiConsole.Write(grid);
                char keyCategory = Console.ReadKey(true).KeyChar;
                _dataManager.SaveData(_productService.Drinks, _productService.Foods, _orderService.Orders, _personService.People);
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
                        _personService.ShowDetails(loggedPerson);
                        break;
                    case '4':
                        AddFoundsToWallet();
                        break;
                    case '5':
                        _orderService.OrdersHistory(_productService, loggedPerson);
                        break;
                    case '6':
                        _personService.ChangePersonalData(loggedPerson);
                        break;
                    case 'p':
                        if (loggedPerson.Basket.Any()) Pay();
                        break;
                    case 'c':
                        if (loggedPerson.Basket.Any()) ClearBasket();
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
                grid.AddEmptyRow();
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
            Console.Clear();
            return _personService.LogIn();
        }

        private void SingUp()
        {
            Console.Clear();
            _personService.SingUp();
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
                AnsiConsole.Markup("[red]\nBasket is empty[/]");
                return;
            }

            var costs = _personService.CalculateBasket(loggedPerson);
            if (loggedPerson.Balance < costs) 
                AnsiConsole.Markup($"[red]\nYou don't have enough money [/]({costs}$)[red] in your wallet.[/]");


            AnsiConsole.Markup($"\n[yellow]Total costs [/]{costs}$[yellow].[/]");

            if (!AnsiConsole.Confirm("\n[yellow]Do you want to pay now? [/]\n")) return;

            if(loggedPerson.Points>0)
            {
                decimal discount = loggedPerson.Points / 10;
                if(discount >= costs) discount = costs;
                if (AnsiConsole.Confirm($"\n[yellow]Do you want to use your points as discount[/](-{discount}$)[yellow] in this order?[/]"))
                {
                    loggedPerson.Points -= (int)discount;
                    AnsiConsole.Markup("[green]Discount Activated[/]");
                }
            }

            var personBasket = loggedPerson.Basket.Select(p => p.Id).ToList<int>();

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

        private void ClearBasket()
        {
            if (loggedPerson.Basket is null)
            {
                AnsiConsole.Markup("[red]Basket is empty[/]");
                return;
            }
            if (!AnsiConsole.Confirm("\n[yellow]Do you want to clear your basket? [/]\n")) return;

            loggedPerson.Basket.Clear();
            AnsiConsole.Markup("[green]Basket is now empty[/]");
        }

        private void AddFoundsToWallet()
        {
            _personService.AddFounds(loggedPerson);
        }

    }
}
