using RestaurantAppProject.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Services
{
    internal class PersonService
    {
        public List<Person> People { get; set; }
        public static int PersonId { get; set; }

        public PersonService()
        {
            People = new List<Person>();
            PersonId = 1;
        }
    }
}
