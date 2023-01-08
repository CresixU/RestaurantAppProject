
namespace RestaurantAppProject.Models.People
{
    public class Client : Person
    {
        public Client(string name, string surname, DateOnly birthdate, string email, string password)
            : base(name, surname, birthdate, email, password)
        {

        }
    }
}
