using RestaurantAppProject.Models;
using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Services
{
    internal class OrderService
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
    }
}
