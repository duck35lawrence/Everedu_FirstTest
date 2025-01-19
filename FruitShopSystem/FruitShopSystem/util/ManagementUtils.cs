using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitShopSystem.data;

namespace FruitShopSystem.util
{
    public class ManagementUtils
    {
        public static T GetItemByProperty<T>(IEnumerable<T> list, Func<T, string> propertySelect, string value)
        {
            foreach (var item in list)
            {
                if(propertySelect(item).Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return default;
        }

        public static Fruit GetFruitById(List<Fruit> fruits, string id)
        {
            return GetItemByProperty(fruits, fruit => fruit.Id, id);
        }

        public static Customer GetCustomerByName(List<Customer> customers, string name)
        {
            return GetItemByProperty(customers, customer => customer.Name, name);
        }

        public static void AddFruitIntoOrder(Customer customer, Fruit fruit)
        {
            bool isExistedItem = false;
            foreach (var existedFruit in customer.Fruits)
            {
                if (fruit.Id == existedFruit.Id)
                {
                    existedFruit.Quantity += fruit.Quantity;
                    isExistedItem = true;
                    break;
                }
            }
            if (!isExistedItem)
            {
                customer.Fruits.Add(fruit);
            }
        }

        public static void ShowFruitsOfCustomer(Customer customer)
        {
            Console.WriteLine("Product | Quantity | Price | Amount");
            double totalAmount = 0;
            foreach (var item in customer.Fruits)
            {
                double amount = item.Quantity * item.Price;
                string price = item.Price.ToString() + "$";
                totalAmount += amount;
                Console.WriteLine(string.Format("{0,-7} | {1,-8} | {2,-5} | {3,-6}",
                    item.Name, item.Quantity, price, amount));
            }
            Console.WriteLine("Total: " + totalAmount);
        }
    }
}
