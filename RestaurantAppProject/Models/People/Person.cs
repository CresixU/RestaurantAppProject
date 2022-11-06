using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.People
{
    internal abstract class Person
    {
        protected Guid Id { get; }
        protected string Name { get; set; }
        protected string Surname { get; set; }
        protected DateOnly Birthdate { get; set; }
        protected string Email { get; set; }
        protected string Password { get; set; }
        protected int Points { get; set; }

        public Person(string name, string surname, DateOnly birthdate, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
            Password = password;
            Points = 0;
        }
    }
}
