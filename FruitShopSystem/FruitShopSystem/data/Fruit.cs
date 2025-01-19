using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShopSystem.data
{
    public class Fruit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Origin { get; set; }

        //for customer
        public Fruit(string id, string name, double price, int quantity, string origin)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Origin = origin;
        }

        //for create
        public Fruit(string id, string name, double price, string origin) 
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = 0;
            Origin = origin;
        }
    }
}
