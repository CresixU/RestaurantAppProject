using RestaurantAppProject.Models.Products;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantAppProject.Interfaces
{
    interface IDrinkable
    {
        void ShowDetails(Table table);

        void Delete(List<Drink> list);
    }
}
