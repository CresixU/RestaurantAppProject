using RestaurantAppProject.Models.Products;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Interfaces
{
    public interface IEatable
    {
        void ShowDetails(Table table);
        void Delete(List<Food> list);
    }
}
