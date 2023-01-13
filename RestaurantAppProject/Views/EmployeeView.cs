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
    public class EmployeeView
    {
        public EmployeeView(ProductService productService, PersonService personService, OrderService orderService, DataManager dataManager)
        {
            _productService = productService;
            _personService = personService;
            _orderService = orderService;
            _dataManager = dataManager;
        }
        private readonly ProductService _productService;
        private readonly PersonService _personService;
        private readonly OrderService _orderService;
        private readonly DataManager _dataManager;

        public void Show(Person person)
        {
            while (true)
            {
                Console.Clear();
                var grid = new Grid();
                grid.AddColumn();
                grid.AddColumn();

                grid.AddRow(new string[] { "Number", "Option" });
                grid.AddRow(new string[] { "[yellow1]  1[/]", "Show all orders" });
                grid.AddRow(new string[] { "[yellow1]  2[/]", "Find all orders by Person ID" });
                grid.AddRow(new string[] { "[yellow1]  3[/]", "Find order by ID" });
                grid.AddEmptyRow();
                grid.AddRow(new string[] { "[yellow1]  Q[/]", "Exit / Customer View" });

                AnsiConsole.Write(grid);
                char keyCategory = Console.ReadKey(true).KeyChar;
                _dataManager.SaveData(_productService.Drinks, _productService.Foods, _orderService.Orders, _personService.People);
                switch (keyCategory)
                {
                    case '1':
                        ShowAllOrders();
                        break;
                    case '2':
                        FindAllOrdersByPersonId();
                        break;
                    case '3':
                        FindOrderById();
                        break;
                    case 'q':
                        person = null;
                        return;
                    default:
                        break;
                }
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        private void ShowAllOrders()
        {
            _orderService.ShowAllOrders(_productService);
            AnsiConsole.Markup("\n\n\n[grey]Press any key to back[/]\n");
        }

        private void FindAllOrdersByPersonId()
        {
            var personId = Validator.Int("[yellow]Insert person id: [/]", 0);
            var person = _personService.People.FirstOrDefault(p => p.Id.Equals(personId));
            if(person == null)
            {
                AnsiConsole.Markup("[red]No person with this id[/]");
                return;
            }
            _orderService.OrdersHistory(_productService, person);
        }

        private void FindOrderById()
        {
            var order = _orderService.FindOrderById();
            if(order == null)
            {
                AnsiConsole.Markup($"\n[red]No order with this id[/]");
                return;
            }
            var owner = _personService.People.FirstOrDefault(p => p.Id.Equals(order.OwnerId));
            Console.Clear();
            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();

            grid.AddRow(new string[] { "[yellow1]ID: [/]", $"{order.Id}" });
            grid.AddRow(new string[] { "[yellow1]Created date: [/]", $"{order.OrderTime}" });
            grid.AddRow(new string[] { "[yellow1]Owener id: [/]", $"{order.OwnerId} {owner.Name} {owner.Surname}" });
            grid.AddRow(new string[] { "[yellow1]Items: [/]", $"{_orderService.GetItemsName(_productService,order.Id)}" });

            AnsiConsole.Write(grid);

            if(AnsiConsole.Confirm("\n\n\n[yellow]\n\n\nDo you want to cancel this order and refund?[/]"))
            {
                _orderService.CancelOrderById(order,_personService);
                AnsiConsole.Markup("\n[green]Order has been canceled.[/]");
            }
        }
    }
}
