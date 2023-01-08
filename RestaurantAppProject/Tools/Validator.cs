using SimpleHashing.Net;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestaurantAppProject.Tools
{
    public class Validator
    {
        public static int Int(string text, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                AnsiConsole.Markup(text);
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number < min || number >= max) throw new Exception("Your number is to big or to small");
                    return number;
                }
                catch (ArgumentNullException)
                {
                    AnsiConsole.Markup("[red]There is no data[/]");
                }
                catch (FormatException)
                {
                    AnsiConsole.Markup("[red]Not a number[/]");
                }
                catch (Exception e)
                {
                    AnsiConsole.Markup($"[red]{e.Message}[/]");
                }
            }
        }

        public static string String(string text, int minLength = 0, int maxLength = 999)
        {
            while (true)
            {
                AnsiConsole.Markup(text);
                try
                {
                    string output = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(output)) throw new Exception("Text is empty");
                    if (output.Length >= maxLength) throw new Exception($"Text should not be longer than {maxLength} characters");
                    if (output.Length <= minLength) throw new Exception($"Text should be longer than {minLength} characters");

                    return output;
                }
                catch (OutOfMemoryException e)
                {
                    AnsiConsole.Markup($"[red]{e.Message}[/]");
                }
                catch (IOException e)
                {
                    AnsiConsole.Markup($"[red]{e.Message}[/]");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    AnsiConsole.Markup($"[red]{e.Message}[/]");
                }
                catch (Exception e)
                {
                    AnsiConsole.Markup($"[red]{e.Message}[/]");
                }
            }
        }

        public static DateOnly Date(string text)
        {
            string[] arrayDate = default;
            while (true)
            {
                var date = String(text, 8, 12);
                arrayDate = date.Split('.');
                string pattern = @"([0-9][0-9])\.([01][0-9])\.([1-9][0-9][0-9][0-9])";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(date)) break;
                else AnsiConsole.Markup("[red]Incorrect date format.[/]");
            }
            


            if (int.TryParse(arrayDate[0], out int result))
            {
                if (result < 1 || result > 31)
                {
                    AnsiConsole.Markup("[red]Incorrect day [/]");
                    return new DateOnly(1, 1, 1);
                }
            }

            if (int.TryParse(arrayDate[1], out result))
            {
                if (result < 1 || result > 12)
                {
                    AnsiConsole.Markup("[red]Incorrect month [/]");
                    return new DateOnly(1,1,1);
                }
            }

            if (int.TryParse(arrayDate[2], out result))
            {
                if (result < (DateTime.Now.Year-120) || result > DateTime.Now.Year)
                {
                    AnsiConsole.Markup("[red]Incorrect year [/]");
                    return new DateOnly(1, 1, 1);
                }
            }

            return new DateOnly(int.Parse(arrayDate[2]), int.Parse(arrayDate[1]), int.Parse(arrayDate[0]));
        }

        public static string Password()
        {
            ISimpleHash passwordHasher = new SimpleHash();
            while (true)
            {
                var password = AnsiConsole.Prompt(new TextPrompt<string>("Enter your password: ").PromptStyle("yellow").Secret());
                var password2 = AnsiConsole.Prompt(new TextPrompt<string>("Enter your password again: ").PromptStyle("yellow").Secret());
                if (password.Equals(password2))
                {
                    string hashedPassword = passwordHasher.Compute(password);
                    return hashedPassword;
                }
                else AnsiConsole.Markup("[red]Incorrect password[/]");
            }
        }
    }
}
