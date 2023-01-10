using RestaurantAppProject.Models.People;
using RestaurantAppProject.Tools;
using SimpleHashing.Net;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantAppProject.Services
{
    public class PersonService
    {
        public List<Person> People { get; set; }
        public static int PersonId { get; set; }

        public PersonService()
        {
            People = new List<Person>();
            PersonId = 1;
        }

        public void ShowDetails(Person person)
        {
            Console.Clear();
            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddRow(new string[] { "Person: ", $"{person.Name} {person.Surname}" });
            grid.AddRow(new string[] { "Email: ", $"{person.Email}" });
            grid.AddRow(new string[] { "Birthdate: ", $"{person.Birthdate}" });
            grid.AddRow(new string[] { "Balance: ", $"{person.Balance}$" });
            grid.AddRow(new string[] { "Points: ", $"{person.Points}" });
            AnsiConsole.Write(grid);

            AnsiConsole.Markup("\n[yellow]Items in basket[/]\n");
            if (person.Basket.Count > 0) DisplayBasket(person);
            else AnsiConsole.Markup("Basket is empty");

            AnsiConsole.Markup("\n\n\n[grey]Press any key to back[/]\n");
        }



        public Person LogIn()
        {
            var mail = Validator.String("[yellow]Insert your Email: [/]", 5, 50);
            var person = People.FirstOrDefault(p => p.Email == mail);
            if (person is null)
            {
                AnsiConsole.Markup("[red]Person with this email was not found[/]");
                Console.ReadKey();
                return null;
            }
            var password = AnsiConsole
                .Prompt(new TextPrompt<string>("[yellow]Enter your password: [/]")
                .PromptStyle("yellow")
            .Secret());

            ISimpleHash passwordHasher = new SimpleHash();
            bool isPasswordValid = passwordHasher.Verify(password, person.Password);

            if(!isPasswordValid)
            {
                AnsiConsole.Markup("[red]Wrong password[/]");
                Console.ReadKey();
                return null;
            }

            return person;
        }

        public void SingUp()
        {
            People.Add(new Client(

                Validator.String("Insert your Name: ", 3, 25),
                Validator.String("Insert your Surname: ", 3, 25),
                Validator.Date("Insert your birthdate (dd.mm.yyyy): "),
                Validator.String("Insert your Email: ", 5, 50),
                Validator.Password()
            ));
            AnsiConsole.Markup("[green]Account succesfully created[/]");
        }

        public void AddFounds(Person person)
        {
            var founds = Validator.Int("\nInsert amout of money you want to add: ");
            if (AnsiConsole.Confirm($"\n[yellow]Are you sure? [/]"))
            {
                person.Balance += founds;
                AnsiConsole.Markup($"\n\n[green]Your wallet has been topped up with [/]{founds}$[green].[/]\n\n[yellow]Your new balance: [/][green]{person.Balance}$[/][yellow].[/] ");
            }
        }

        public decimal CalculateBasket(Person person)
        {
            var costs = 0.00m;
            costs = person.Basket.Sum(i => i.Price);
            return costs;
        }

        public void ChangePersonalData(Person person)
        {
            Console.Clear();
            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();

            grid.AddRow(new string[] { "Number", "Option" });
            grid.AddRow(new string[] { "[yellow1]  1[/]", "Email" });
            grid.AddRow(new string[] { "[yellow1]  2[/]", "Password" });
            grid.AddEmptyRow();
            grid.AddRow(new string[] { "[yellow1]  Q[/]", "Exit" });
            AnsiConsole.Markup("[yellow]What do you want to change?[/]\n");
            AnsiConsole.Write(grid);
            char keyCategory = Console.ReadKey(true).KeyChar;
            switch (keyCategory)
            {
                case '1':
                    ChangeEmail(person);
                    break;
                case '2':
                    ChangePassword(person);
                    break;
                default:
                    break;
            }
        }

        private void DisplayBasket(Person person)
        {
            if (person.Basket == null)
            {
                AnsiConsole.Markup("[green]Basket is empty[/]");
            }

            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddRow(new string[] { "[yellow]Price[/]", "[yellow]Item[/]" });

            foreach (var item in person.Basket)
            {
                grid.AddRow(new string[] { $"{item.Price}", $"[grey70]{item.Name}[/]" });
            }
            AnsiConsole.Write(grid);
            AnsiConsole.Markup($"\n[yellow]Total:[/] [yellow1]{CalculateBasket}$[/]");
        }

        private void ChangeEmail(Person person)
        {
            Console.Clear();
            var newMail = Validator.String("[yellow1]New E-mail: [/]", 5, 100);
            person.Email = newMail;
            AnsiConsole.Markup("\n[green]Email has been changed[/]");
        }

        private void ChangePassword(Person person)
        {
            Console.Clear();
            ISimpleHash hasher = new SimpleHash();
            var password = AnsiConsole.Prompt(new TextPrompt<string>("Enter your password: ").PromptStyle("yellow").Secret());
            if(hasher.Verify(password,person.Password))
            {
                AnsiConsole.Markup("[yellow1]Now new password[/]");
                person.Password = Validator.Password();
                AnsiConsole.Markup("[green]Password has changed[/]");
            }
            else AnsiConsole.Markup("[red]Incorrect password[/]");
        }


    }
}
