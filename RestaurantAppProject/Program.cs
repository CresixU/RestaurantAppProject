using RestaurantAppProject.Models.Products;
using RestaurantAppProject.Models.Products.Drinks;

namespace RestaurantAppProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AlcoholService alcoholService = new AlcoholService();
            alcoholService.Create("Wódka", "Czysta polska żubrówka", 20.00M, 700, 40.00M);
            alcoholService.ShowAll();
        }
    }
}