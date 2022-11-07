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
        public List<Order> orders = new List<Order>();

        public void Create(List<Item> items, decimal price,Person owner)
        {

            orders.Add(new Order(items, price, owner));
        }
    }
}
