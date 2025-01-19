using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitShopSystem.util;

namespace FruitShopSystem.ui
{
    public class Menu
    {
        public string Title { get; private set; }
        public List<string> opionList = new List<string>();

        public Menu(string title)
        {
            Title = title;
        }

        public void AddNewOption(string newOption)
        {
            opionList.Add(newOption);
        }

        public void ShowMenu()
        {
            int count = 1;
            Console.WriteLine("\n" + Title);
            foreach (String option in opionList)
            {
                Console.WriteLine(count + ". " + option);
                count++;
            }
        }

        public int GetChoice()
        {
            int choice = Inputter.GetAnInteger(
                "Input your choice: ",
                "Your choice must between 1 and " + opionList.Count,
                1, opionList.Count);
            return choice;
        }
    }
}
