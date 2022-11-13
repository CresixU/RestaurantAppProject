using RestaurantAppProject.Models.Products;
using RestaurantAppProject.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.People
{
    internal abstract class Person
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
        public List<Product> Basket { get; set; }

        public Person(string name, string surname, DateOnly birthdate, string email, string password)
        {
            Id = PersonService.PersonId++;
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
            Password = password;
            Points = 0;
            Basket = new List<Product>();
        }
    }
}
