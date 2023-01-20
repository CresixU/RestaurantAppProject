using RestaurantAppProject.Models;
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
    public class OrderService
    {
        public List<Order> Orders { get; set; }
        public static int OrderId { get; set; }
        public OrderService()
        {
            Orders = new List<Order>();
            OrderId = 1;
        }

        public void Create(List<int> items, decimal price,int owner)
        {
            Orders.Add(new Order(items, price, owner));
        }

        public void OrdersHistory(ProductService productService, Person person)
        {
            var orders = Orders.FindAll(o => o.OwnerId == person.Id);

            if(!orders.Any())
            {
                AnsiConsole.Markup("[yellow1]There is no orders yet[/]");
                return;
            }

            Console.Clear();
            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddRow(new string[] { "[yellow1]ID[/]", "[yellow1]Date[/]", "[yellow1]Price[/]", "[yellow1]Items[/]" });
            grid.AddRow(new string[] { "", "", "", "" });
            foreach (var order in orders)
            {
                grid.AddRow(new string[] { $"{order.Id}", $"{order.OrderTime}", $"{order.Price}", $"{GetItemsName(productService, order.Id)}" });
            }
            AnsiConsole.Write(grid);

            AnsiConsole.Markup("\n\n\n[grey]Press any key to back[/]\n");

        }

        public Order FindOrderById()
        {
            if (!Orders.Any())
            {
                AnsiConsole.Markup("[yellow1]There is no orders yet[/]");
                return null;
            }

            var orderId = Validator.Int("[yellow]Insert order id: [/]");
            var order = Orders.FirstOrDefault(o => o.Id.Equals(orderId));

            return order;
        }

        public void ShowAllOrders(ProductService productService)
        {
            if(!Orders.Any())
            {
                AnsiConsole.Markup("[yellow1]There is no orders yet[/]");
                return;
            }

            Console.Clear();
            var grid = new Grid();
            grid.AddColumns(5);
            grid.AddRow(new string[] { "[yellow1]ID[/]", "[yellow1]Date[/]", "[yellow1]Price[/]", "[yellow1]Items[/]", "[yellow1]Owner[/]" });
            grid.AddRow(new string[] { "", "", "", "","" });
            foreach (var order in Orders)
            {
                grid.AddRow(new string[] { $"{order.Id}", $"{order.OrderTime}", $"{order.Price}", $"{GetItemsName(productService, order.Id)}", $"{order.OwnerId}" });
            }
            AnsiConsole.Write(grid);


        }


        public string GetItemsName(ProductService productService, int orderId)
        {
            var order = Orders.FirstOrDefault(o => o.Id == orderId);

            var foodNames = productService
                .Foods
                .FindAll(f => order.Items.Contains(f.Id))
                .Select(p => p.Name);
            
            var itemNames = productService
                .Drinks
                .FindAll(f => order.Items.Contains(f.Id))
                .Select(p => p.Name)
                .Concat(foodNames);
                

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in itemNames)
            {
                stringBuilder.Append(item+", ");
            }

            return stringBuilder.ToString();
        }

        public void CancelOrderById(Order order, PersonService personService)
        {
            var owner = personService.People.FirstOrDefault(p => p.Id.Equals(order.Id));
            owner.Balance += (decimal)MathF.Round((float)order.Price,2);
            owner.Points -= (int)(order.Price / 10);
            Orders.Remove(order);
        }
    }
}
