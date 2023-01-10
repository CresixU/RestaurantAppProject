using RestaurantAppProject.Models.People;
using RestaurantAppProject.Services;
using RestaurantAppProject.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Views
{
    public class ClientView
    {
        public ClientView(ProductService productService, PersonService personService, OrderService orderService, DataManager dataManager)
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


    }
}
