using System;
using FruitShopSystem.data;
using FruitShopSystem.ui;
class Program
{
    public static void Main()
    {
        Menu menu = new Menu("FRUIT SHOP SYSTEM");
        menu.AddNewOption("Create Fruit");
        menu.AddNewOption("View orders");
        menu.AddNewOption("Shopping(for buyer)");
        menu.AddNewOption("Exit");

        FruitShop fsSystem = new FruitShop();
        int choice = 0;
        do
        {
            menu.ShowMenu();
            choice = menu.GetChoice();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    fsSystem.CreateFruit();
                    break;
                case 2:
                    fsSystem.ViewOrdersList();
                    break;
                case 3:
                    fsSystem.Shopping();
                    break;
                case 4:
                    Console.WriteLine("Exit");
                    break;
            }
        } while (choice != 4);
    }
}

