using RestaurantAppProject.Models.Products;
using RestaurantAppProject.Services;
using Spectre.Console;

namespace RestaurantAppProject.Models.People
{
    public class Person
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
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
            Balance = 0;
            Basket = new List<Product>();
        }

        public void ShowDetails()
        {
            Console.Clear();
            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddRow(new string[] { "Person: ", $"{Name} {Surname}"});
            grid.AddRow(new string[] { "Email: ", $"{Email}"});
            grid.AddRow(new string[] { "Birthdate: ", $"{Birthdate}" });
            grid.AddRow(new string[] { "Balance: ", $"{Balance}$" });
            grid.AddRow(new string[] { "Points: ", $"{Points}" });
            AnsiConsole.Write(grid);

            AnsiConsole.Markup("\n[yellow]Items in basket[/]\n");
            if (Basket.Count > 0) DisplayBasket();
            else AnsiConsole.Markup("Basket is empty");

            AnsiConsole.Markup("\n\n\n[grey]Press any key to back[/]\n");
        }

        private void DisplayBasket()
        {
            if (Basket == null)
            {
                AnsiConsole.Markup("[green]Basket is empty[/]");
            }

            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddRow(new string[] { "[yellow]Price[/]", "[yellow]Item[/]" });
            
            foreach (var item in Basket)
            {
                grid.AddRow(new string[] { $"{item.Price}", $"[grey70]{item.Name}[/]" });
            }
            AnsiConsole.Write(grid);
            AnsiConsole.Markup($"\n[yellow]Total:[/] [yellow1]{CalculateBasket}$[/]");
        }

        public decimal CalculateBasket()
        {
            var costs = 0.00m;
            costs = Basket.Sum(i => i.Price);
            return costs;
        }
    }
}
