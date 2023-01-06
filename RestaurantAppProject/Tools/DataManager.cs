using RestaurantAppProject.Models;
using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products;

namespace RestaurantAppProject.Tools
{
    public class DataManager
    {
        public List<object> LoadData(List<Drink> drinks, List<Food> food, List<Order> orders, List<Person> people)
        {
            drinks = JsonSerializer<Drink>.LoadData("drinks.json").Result;
            food = JsonSerializer<Food>.LoadData("food.json").Result;
            orders = JsonSerializer<Order>.LoadData("orders.json").Result;
            people = JsonSerializer<Person>.LoadData("people.json").Result;

            return new List<object> { drinks, food, orders, people };
        }

        public void SaveData(List<Drink> drinks, List<Food> food, List<Order> orders, List<Person> people)
        {
            JsonSerializer<Drink>.SaveData(drinks, "drinks.json");
            JsonSerializer<Food>.SaveData(food, "food.json");
            JsonSerializer<Order>.SaveData(orders,"orders.json");
            JsonSerializer<Person>.SaveData(people,"people.json");
        }
    }
}
