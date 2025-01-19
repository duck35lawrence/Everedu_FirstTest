using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitShopSystem.util;

namespace FruitShopSystem.data
{
    public class FruitShopManagement
    {
        private List<Customer> customers = new List<Customer>();
        private List<Fruit> fruits = new List<Fruit>();

        public void CreateFruit()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Create Fruit");
                //input infor
                string id = "";
                bool isDup = false;
                //input id and check duplicate
                do
                {
                    isDup = false;
                    id = Inputter.GetString(
                        "Input fruit id: ",
                        "Id can not be empty.");
                    if (ManagementUtils.GetFruitById(fruits, id) != null)
                    {
                        isDup = true;
                        Console.WriteLine("This id is existed");
                    }
                } while (isDup);
                //input other infor
                string name = Inputter.GetString("Input fruit name: ", "Name can not be empty");
                double price = Inputter.GetADouble("Input price: ", "Price is greater than 0", 0);
                string origin = Inputter.GetString("Input fruit origin: ", "Origin can not be empty.");

                fruits.Add(new Fruit(id, name, price, origin));

                //ask for continue
                bool isContinue = Inputter.GetBoolean("Do you want to continue (Y/N)?: ", "Y or N only.",
                    "Y", "N");
                if (!isContinue) break;
            }
        }

        public void ViewOrdersList()
        {
            Console.Clear ();
            Console.WriteLine("View Orders List");
            //Nếu list empty
            if(customers.Count == 0)
            {
                Console.WriteLine("No customer is available.");
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine("\nCustomer: " + customer.Name);
                ManagementUtils.ShowFruitsOfCustomer(customer);
            }
        }

        public void Shopping()
        {
            Console.Clear ();
            Console.WriteLine("Shopping");
            //nếu list empty
            if (fruits.Count == 0) 
            { 
                Console.WriteLine("No fruit is avaiable.");
                return; 
            }
            Customer customer = new Customer();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Shopping");
                Console.WriteLine("| ++ Item ++ | ++ Fruit Name ++ | ++ Origin ++ | ++ Price ++ |");
                foreach (var item in fruits)
                {
                    string price = item.Price.ToString() + "$";
                    Console.WriteLine(string.Format("|{0,7}     |  {1,-15} |  {2,-11} |    {3,-8} |",
                        item.Id, item.Name, item.Origin, price));
                }
                string fruitId = Inputter.GetString("Input fruit Id: ", "Id can not be empty");
                Fruit fruit = ManagementUtils.GetFruitById(fruits, fruitId);
                int quantityBuy = 0;
                if (fruit == null) Console.WriteLine("Fruit not found");
                else
                {
                    Console.WriteLine("You selected: " + fruit.Name);
                    quantityBuy = Inputter.GetAnInteger("Input quantity: ", "Quantity can not be empty.", 1);
                    customer.Fruits.Add(new Fruit(fruit.Id, fruit.Name, fruit.Price, quantityBuy, fruit.Origin));
                }

                //ask for continue
                bool isContinue = Inputter.GetBoolean("Do you want to order now (Y/N)?: ", "Y or N only.",
                    "Y", "N");
                if (!isContinue)
                {
                    ManagementUtils.ShowFruitsOfCustomer(customer);
                    //Nhập name cho customer
                    string name = Inputter.GetString("Input your name: ", "Name can not be empty.");
                    Customer existedCustomer = ManagementUtils.GetCustomerByName(customers, name);
                    if (existedCustomer == null)
                    {
                        customer.Name = name;
                        customers.Add(customer);
                    }
                    else
                    {
                        Console.WriteLine("Customer is existed.");
                        bool isReplace = Inputter.GetBoolean(
                            "You want to replace (R) or add (A) the new order. (R/A)?: ",
                            "R or A only.",
                            "R", "A");
                        if (isReplace)
                        {
                            existedCustomer.Fruits = customer.Fruits;
                        }
                        else
                        {
                            //duyệt từng fruit của order mới
                            foreach (var item in customer.Fruits)
                            {
                                //duyệt từng fruit của order cũ
                                foreach (var existedItem in existedCustomer.Fruits)
                                {
                                    //nếu trùng id thì cộng dồn quantity
                                    if (item.Id == existedItem.Id)
                                        existedItem.Quantity += item.Quantity;
                                    else
                                        existedCustomer.Fruits.Add(item);
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