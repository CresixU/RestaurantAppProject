using RestaurantAppProject.Models.Products;
using RestaurantAppProject.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Services
{
    internal class ProductService
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


    }
}
