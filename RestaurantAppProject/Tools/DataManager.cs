using RestaurantAppProject.Models;
using RestaurantAppProject.Models.People;
using RestaurantAppProject.Models.Products;

namespace RestaurantAppProject.Tools
{
    internal class DataManager
    {
        public static void LoadData(List<Drink> drinks, List<Food> food, List<Order> orders, List<Person> people)
        {
            drinks = JsonSerializer<Drink>.LoadData("drinks.json");
            food = JsonSerializer<Food>.LoadData("food.json");
            orders = JsonSerializer<Order>.LoadData("orders.json");
            people = JsonSerializer<Person>.LoadData("people.json");
        }

        public static void SaveData(List<Drink> drinks, List<Food> food, List<Order> orders, List<Person> people)
        {
            JsonSerializer<Drink>.SaveData(drinks, "drinks.json");
            JsonSerializer<Food>.SaveData(food, "food.json");
            JsonSerializer<Order>.SaveData(orders,"orders.json");
            JsonSerializer<Person>.SaveData(people,"people.json");
        }
    }
}
