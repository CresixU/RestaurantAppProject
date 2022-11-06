using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.People
{
    internal class Employee : Person
    {
        public Employee(string name, string surname, DateOnly birthdate, string email, string password)
            : base(name, surname, birthdate, email, password)
        {
        }
    }
}
