using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitShopSystem.util;

namespace FruitShopSystem.data
{
    public class FruitShop
    {
        private List<Customer> customers = new List<Customer>();
        private List<Fruit> fruits = new List<Fruit>();

        public Fruit GetFruitById(string id)
        {
            foreach (Fruit fruit in fruits)
            {
                if (fruit.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    return fruit;
            }
            return null;
        }

        public Customer GetCustomerByName(string name)
        {
            foreach (var customer in customers)
            {
                if (customer.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return customer;
            }
            return null;
        }

        public void CreateFruit()
        {
            while (true)
            {
                //input infor
                string id = "";
                bool isDup = false;
                do
                {
                    id = Inputter.GetString(
                        "Input fruit id: ",
                        "Id can not be empty.");
                    if (GetFruitById(id) != null)
                    {
                        isDup = true;
                        Console.WriteLine("This id is existed");
                    }
                } while (isDup);

                string name = Inputter.GetString(
                    "Input fruit name: ",
                    "Name can not be empty");
                double price = Inputter.GetADouble(
                    "Input price: ",
                    "Price is greater than 0",
                    0);
                //int quantity = Inputter.GetAnInteger(
                //    "Input fruit quantiy: ",
                //    "Quantity is greater than 0.",
                //    0);
                string origin = Inputter.GetString(
                    "Input fruit origin: ",
                    "Origin can not be empty.");

                fruits.Add(new Fruit(id, name, price, origin));

                //ask for continue
                bool isContinue = Inputter.GetBoolean(
                    "Do you want to continue (Y/N)?: ",
                    "Y or N only.",
                    "Y", "N");
                if (!isContinue) break;
            }
        }

        public void ViewOrdersList()
        {
            if(!customers.Any())
            {
                Console.WriteLine("No customer is available");
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine("Customer: " + customer.Name);
                Console.WriteLine("Product | Quantity | Price | Amount");
                double total = 0;
                foreach (var fruit in customer.Fruits)
                {
                    double amount = fruit.Quantity * fruit.Price;
                    string price = fruit.Price.ToString() + "$";
                    total += amount;
                    string str = string.Format("{0,-7} | {1,-8} | {2,-5} | {3,-6}",
                        fruit.Name, fruit.Quantity, price, amount);
                    Console.WriteLine(str);
                }
                Console.WriteLine("Total: " + total);
            }
        }

        public void Shopping()
        {
            if(!fruits.Any()) 
            { 
                Console.WriteLine("Shop is empty.");
                return; 
            }
            Customer customer = new Customer();
            while (true)
            {
                Console.WriteLine("| ++ Item ++ | ++ Fruit Name ++ | ++ Origin ++ | ++ Price ++ |");
                foreach (var item in fruits)
                {
                    string price = item.Price.ToString() + "$";
                    string str = string.Format("|{0,7}     |  {1,-15} |  {2,-11} |    {3,-8} |",
                        item.Id, item.Name, item.Origin, price);
                    Console.WriteLine(str);
                }
                string fruitId = Inputter.GetString(
                    "Input fruit Id: ",
                    "Id can not be empty");
                Fruit fruit = GetFruitById(fruitId);
                int quantityBuy = 0;
                if (fruit == null) Console.WriteLine("Fruit not found");
                else
                {
                    Console.WriteLine("You selected: " + fruit.Name);
                    quantityBuy = Inputter.GetAnInteger(
                        "Input quantity: ",
                        "Quantity can not be empty.",
                        1);
                }

                //ask for continue
                bool isContinue = Inputter.GetBoolean(
                    "Do you want to order now (Y/N)?: ",
                    "Y or N only.",
                    "Y", "N");
                if (fruit != null)
                {
                    customer.Fruits.Add(new Fruit(fruit.Id, fruit.Name, fruit.Price, quantityBuy, fruit.Origin));
                }
                if (!isContinue)
                {
                    double total = 0;
                    Console.WriteLine("Product | Quantity | Price | Amount");
                    foreach (var item in customer.Fruits)
                    {
                        double amount = item.Quantity * item.Price;
                        string price = item.Price.ToString() + "$";
                        string str = string.Format("{0,-7} | {1,-8} | {2,-5} | {3,-6}",
                            item.Name, item.Quantity, price, amount);
                        total += amount;
                        Console.WriteLine(str);
                    }
                    Console.WriteLine("Total: " + total);

                    string name = Inputter.GetString(
                        "Input your name: ",
                        "Name can not be empty.");
                    Customer existedCustomer = GetCustomerByName(name);
                    if (existedCustomer == null)
                    {
                        customer.Name = name;
                        customers.Add(customer);
                    }
                    else
                    {
                        Console.WriteLine("Customer is existed.");
                        bool isReplace = Inputter.GetBoolean(
                            "You want to replace (R) or add (A) the new order. (R/A)?:  ",
                            "R or A only.",
                            "R", "A");
                        if (isReplace)
                        {
                            existedCustomer.Fruits = customer.Fruits;
                        }
                        else
                        {
                            foreach (var item in customer.Fruits)
                            {
                                foreach (var existedItem in existedCustomer.Fruits)
                                {
                                    if(item.Id == existedItem.Id)
                                    {
                                        existedItem.Quantity += item.Quantity;
                                    }
                                    else { 
                                        existedCustomer.Fruits.Add(item);
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
            }
        }
    }
}