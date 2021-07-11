using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    class ProgramUI
    {
       private readonly IMenuRepository _menuRepo;
        
       public ProgramUI(IMenuRepository repo)
        {
            _menuRepo = repo;
        }
       public void Run()
        {
            GetUserResponse();
        }
       private void GetUserResponse()
       {
            Console.Clear();
            Console.WriteLine("Please select from the following options:\n" +
                "1->Create a new item to menu\n" +
                "2->Get a list of all menu items\n" +
                "3->Remove an existing item in menu\n" +
                "4->Exit");

            char response = Console.ReadKey().KeyChar;
            EvaluateUserResponse(response);
       }
       private void EvaluateUserResponse(char response)
        {
            switch(response)
            {
                case '1':
                    AddNewItem();
                    break;
                case '2':
                    PrintMenu();
                    break;
                case '3':
                    RemoveExistingItem();
                    break;
                case '4':
                    Exit();
                    break;
                default:
                    GetUserResponse();
                    break;
            }
        }
       private void ReturnToMenu()
        {
            Console.WriteLine("Press Enter to return to menu");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                GetUserResponse();
            else
                ReturnToMenu();
        }
       private void AddNewItem()
        {
            Console.Clear();

            Console.Write("ID Number: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Ingredients(COMMA SEPARATED): ");
            List<string> ingredients = Console.ReadLine().Split(',').ToList();
            foreach (var item in ingredients)
                item.Trim();

            Console.Write("Price($): ");
            decimal price = decimal.Parse(Console.ReadLine());

            MenuItem newItem = new MenuItem(id, name, description, ingredients, price);
            bool succeeded = _menuRepo.CreateMenuItem(newItem);

            if (succeeded)
                Console.WriteLine($"{name} has been added to the menu");
            else
                Console.WriteLine("No item was added");

            ReturnToMenu();
        }
       private void PrintItem(MenuItem item)
        {
            Console.WriteLine($"{item.Id} {item.Name} ${item.Price}\n{item.Description}");
            foreach (var ingredient in item.Ingredients)
            {
                Console.WriteLine(ingredient.Trim());
            }
        }
       private void PrintMenu()
        {
            Console.Clear();
            if (_menuRepo.GetMenu().Count > 0)
            {
                foreach (var item in _menuRepo.GetMenu())
                {
                    PrintItem(item);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The menu is empty!");
            }

            ReturnToMenu();
        }
       private void RemoveExistingItem()
        {
            Console.Clear();
            if(_menuRepo.GetMenu().Count > 0)
            {
                foreach (var item in _menuRepo.GetMenu())
                {
                    Console.WriteLine($"{item.Id}->{item.Name}");
                }

                Console.Write("\nEnter the id of the item to delete: ");
                int deleteId = int.Parse(Console.ReadLine());
                bool removed = _menuRepo.DeleteMenuItem(deleteId);

                if (removed)
                    Console.WriteLine("Item deleted");
                else
                    Console.WriteLine("No item was removed");
            }
            else
                Console.WriteLine("There are no items to delete");

            ReturnToMenu();
        }
       private void Exit()
        {
            Console.Clear();
            Console.WriteLine("Press ENTER to return to menu");
            Console.WriteLine("Press SPACEBAR to exit");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                GetUserResponse();
            else if (key.Key == ConsoleKey.Spacebar)
                return;
            else
                Exit();
        }
    }
}
