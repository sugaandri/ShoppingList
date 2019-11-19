using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert what do you want to have from the shop. Seperate items with comma.");
            string userInput;
            userInput = Console.ReadLine();
            var shoppingList = new List<string>(userInput.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries));
            Start:
            Console.WriteLine("Here are your items:");
            foreach (var item in shoppingList)
            {
                Console.WriteLine(item);
            }
            if (AskPermission() == true)
            {
                AddItems(shoppingList);
            }
            else
            {
                RemoveItems(shoppingList);
            }
            ShowList(shoppingList);
            if (CheckUsersList() == false)
            {
                goto Start;
            }
        }

        public static Boolean AskPermission()
        {
        Start:
            string userAnswer;
            Console.WriteLine("Do you want to add or remove any items?");
            userAnswer = Console.ReadLine().ToLower();
            if (userAnswer == "add")
            {
                Console.Clear();
                return true;
            }
            else if (userAnswer == "remove")
            {
                Console.Clear();
                return false;
            }
            else
            {
                Console.WriteLine("Please type 'add' or 'remove' ");
                goto Start;
            }
        }

        public static void AddItems(List<string> shoppingList)
        {
            string newItem;
            Console.WriteLine("Please insert all items which you want to add, seperated by comma.");
            newItem = Console.ReadLine().ToLower();
            var moveItems = new List<string>(newItem.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries));
            foreach(string item in moveItems)
            {
                shoppingList.Add(item);
            }
            Console.Clear();
        }

        public static void RemoveItems(List<string> shoppingList)
        {
            string newItem;
            Console.WriteLine("Please insert all items which you want to remove, seperated by comma.");
            newItem = Console.ReadLine().ToLower();
            var moveItems = new List<string>(newItem.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries));
            foreach (string item in moveItems)
            {
                shoppingList.Remove(item);
            }
            Console.Clear();     
        }

        public static void ShowList(List<string> shoppingList)
        {
            int counter = 0;
            foreach(string item in shoppingList)
            {
                counter++;
            }
            Console.WriteLine($"Here are your {counter} items:");
            foreach(string item in shoppingList)
            {
                Console.WriteLine(item);
            }
        }

        public static Boolean CheckUsersList()
        {
            Start:
            Console.WriteLine("Are you happy with your list?");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                Console.WriteLine("You are ready to go shopping!");
                return true;
                Console.ReadLine();
                
            }
            else if (answer == "no")
            {
                Console.Clear();
                return false;
                
            }
            else
            {
                Console.WriteLine("Please insert 'yes' or 'no'");
                goto Start;
            }
        }
    }
}
