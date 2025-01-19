using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShopSystem.data
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Fruit> Fruits { get; set; }

        public Customer() 
        {
            Fruits = new List<Fruit>();
        }

        public Customer(string name) 
        {
            Name = name;
            Fruits = new List<Fruit>();
        }
    }
}
