using RestaurantAppProject.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Services.People
{
    internal class ClientService
    {
        public List<Client> clients = new List<Client>();

        public void Create(string name, string surname, DateOnly birthdate, string email, string password)
        {
            clients.Add(new Client(name, surname, birthdate, email, password));
        }

        public void DisplayData(Client client)
        {
            Console.WriteLine($"{client.Name} {client.Surname}");
            Console.WriteLine($"{client.Email}");
            Console.WriteLine($"{client.Birthdate}");
            Console.WriteLine($"{client.Points}");
        }
    }
}
