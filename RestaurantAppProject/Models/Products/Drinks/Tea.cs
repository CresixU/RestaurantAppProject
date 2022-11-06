using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppProject.Models.Products
{
    internal class Tea : Drink
    {
        public TeaType Type { get; set; }

        public Tea(string name, string description, decimal price, int capacity,TeaType type)
            : base(name, description, price, capacity)
        {
            Type = type;
        }


    }

    enum TeaType
    {
        Black,
        Green,
        Herbal,
        White,
        Oolong,
        Rooibos
    }
}
