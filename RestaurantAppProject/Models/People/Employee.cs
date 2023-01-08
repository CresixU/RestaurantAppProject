
namespace RestaurantAppProject.Models.People
{
    public class Employee : Person
    {
        public Employee(string name, string surname, DateOnly birthdate, string email, string password)
            : base(name, surname, birthdate, email, password)
        {
        }
    }
}
