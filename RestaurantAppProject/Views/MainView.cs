using RestaurantAppProject.Models.People;
using RestaurantAppProject.Services;
using RestaurantAppProject.Tools;
using Spectre.Console;

namespace RestaurantAppProject.Views
{
    public class MainView
    {
        public MainView(ProductService productService, PersonService personService, OrderService orderService, DataManager dataManager)
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
            while (true)
            {
                if (loggedPerson is null) ShowMainViewGuest();
                if (loggedPerson != null) ShowCategories();
            }
        }

        private void ShowCategories()
        {
            ClientView clientView = new ClientView(_productService, _personService, _orderService, _dataManager);
            if (loggedPerson.Email.Contains("@local"))
            {
                EmployeeView employeeView = new EmployeeView(_productService,_personService,_orderService,_dataManager);
                employeeView.Show(loggedPerson);
            }
            while (true)
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
                        clientView.AddToBasketOrSkip("food");
                        break;
                    case '2':
                        ProductService.ShowDrink(_productService.Drinks);
                        clientView.AddToBasketOrSkip("drink");
                        break;
                    case '3':
                        _personService.ShowDetails(loggedPerson);
                        break;
                    case '4':
                        _personService.AddFounds(loggedPerson);
                        break;
                    case '5':
                        _orderService.OrdersHistory(_productService, loggedPerson);
                        break;
                    case '6':
                        _personService.ChangePersonalData(loggedPerson);
                        break;
                    case 'p':
                        if (loggedPerson.Basket.Any())
                            clientView.Pay();
                        break;
                    case 'c':
                        if (loggedPerson.Basket.Any()) 
                            _personService.ClearBasket(loggedPerson);
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
        private void ShowMainViewGuest()
        {
            do
            {
                Console.Clear();
                var grid = new Grid();
                grid.AddColumn();
                grid.AddColumn();

                grid.AddRow(new string[] { "Number", "Option" });
                grid.AddRow(new string[] { "[yellow1]  1[/]", "Log in" });
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


    }
}
