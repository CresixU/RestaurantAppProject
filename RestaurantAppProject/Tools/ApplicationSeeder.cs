using RestaurantAppProject.Models;
using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products;
using RestaurantAppProject.Models.Products.Drinks;
using RestaurantAppProject.Models.Products.Foods;
using RestaurantAppProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Tools
{
    internal class ApplicationSeeder
    {
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        private readonly PersonService _personService;

        public ApplicationSeeder(ProductService productService, OrderService orderService, PersonService personService)
        {
            _productService = productService;
            _orderService = orderService;
            _personService = personService;
        }
        public void Seed()
        {
            _productService.Drinks.Add(new Alcohol("Wódka", "Czysta polska", 20.00M, 50, 40.00M));
            _productService.Drinks.Add(new Coffee("Kawa", "Opis", 7.99M, 200));
            _productService.Drinks.Add(new ColdDrink("Cola", "Cola opis", 3.52M, 350));
            _productService.Drinks.Add(new Tea("Yellow Label", "tea opis", 5.50M, 300,TeaType.Rooibos));

            _productService.Foods.Add(new Breakfast("Jajecznica", "Jajecznica z szczypiorkiem i pieczarkami", 13.99M, new List<string>() { "szczypiorek", "pieczarki" }));
            _productService.Foods.Add(new Dessert("Lody bakaliowe", "Lody z bakaliami na zimno", 17.39M, new List<string>() { "bakalie" }));
            _productService.Foods.Add(new Lunch("Schabowy", "Schabowy z ziemniakami i surówką", 22.00M, new List<string>() { "wieprzowina", "ziemniaki", "kapusta", "marchewka", "sałata", "pomidor" }));
            _productService.Foods.Add(new Pasta("Spaghetti", "Spaghetti Boloniese", 19.50M, new List<string>() { "makaron", "pomidory", "wieprzowina" }));
            _productService.Foods.Add(new Pizza("Pizza Carbonarra", "Pizza Carbonara", 10M, new List<string>() { "makaron", "jajka", "panceta", "ser pecorino" }, PizzaSize.medium));
            _productService.Foods.Add(new Soup("Pomidorowa", "Zupa pomidorowa", 7M, new List<string>() { "makaron", "marchew", "pietruszka", "seler" }));


            _personService.People.Add(new Client("John", "Doe", new DateOnly(1986,1,20), "johndoe@mail.com", "Rfc2898DeriveBytes$50000$re7YP3aJzqWKDZrrPSJK+g==$b3+Jc38YI3okEK0Eyap4HBd97O5p5o61SMevxAFobFs=")); //password
            _personService.People.Add(new Client("Will", "Smith", new DateOnly(1972, 5, 12), "willsmith@mail.com", "Rfc2898DeriveBytes$50000$re7YP3aJzqWKDZrrPSJK+g==$b3+Jc38YI3okEK0Eyap4HBd97O5p5o61SMevxAFobFs=")); //password
            _personService.People.Add(new Employee("Toby", "O'brian", new DateOnly(1999, 9, 30), "tobyobrian@gmail.com", "Rfc2898DeriveBytes$50000$re7YP3aJzqWKDZrrPSJK+g==$b3+Jc38YI3okEK0Eyap4HBd97O5p5o61SMevxAFobFs=")); //password

            _orderService.Orders.Add(new Order(new List<int>() { 4, 6, 7 }, 45.89M, 1));
            _orderService.Orders.Add(new Order(new List<int>() { 1, 3, 5 }, 30.25M, 2));
        }
    }
}
