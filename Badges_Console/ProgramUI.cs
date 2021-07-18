using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badges_Repository;

namespace Badges_Console
{
    class ProgramUI
    {
        private readonly IBadgeRepository _badgeRepo;
        public ProgramUI(IBadgeRepository repo)
        {
            _badgeRepo = repo;
        }

        public void Run()
        {
            GetUserResponse();
        }
        private void GetUserResponse()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin. What would you like to do?\n" +
                              "1. Create a new badge\n" +
                              "2. Update doors on an existing badge\n" +
                              "3. Delete all doors from an existing badge\n" +
                              "4. Show a list with all badge numbers and door access\n");

            char response = Console.ReadKey().KeyChar;
            EvaluateUserResponse(response);
        }

        private void EvaluateUserResponse(char response)
        {
            Console.Clear();

            switch (response)
            {
                case '1':
                    CreateNewBadge();
                    break;
                case '2':
                    UpdateDoorsInBadge();
                    break;
                case '3':
                    DeleteDoorsFromBadge();
                    break;
                case '4':
                    ShowAllBadges();
                    break;
                default:
                    GetUserResponse();
                    break;
            }

            ReturnToMenu();
        }
        private void CreateNewBadge()
        {
            Console.WriteLine("CREATING A NEW BADGE!\n");
           
            Console.Write("Enter Badge ID: ");
            Badge newbadge = new Badge(int.Parse(Console.ReadLine()));

            Console.Write("Enter badge name: ");
            newbadge.Name = Console.ReadLine();

            Console.WriteLine("List all doors this badge needs access to(COMMA SEPARATED): ");
            newbadge.Doors = Console.ReadLine().Split(',').ToList();
            for (int i = 0; i < newbadge.Doors.Count; i++)
            {
                newbadge.Doors[i] = newbadge.Doors[i].Trim();
            }

            if (_badgeRepo.CreateBadge(newbadge))
                Console.WriteLine("New badge created");
            else
                Console.WriteLine("No badge was created");
        }
        private void UpdateDoorsInBadge()
        {
            if(_badgeRepo.GetBadges.Count > 0)
            {
                Console.WriteLine("UPDATING DOORS IN A BADGE\n");
                ShowAllBadges();
                Console.WriteLine();
                Console.WriteLine("What would you like to do?\n" +
                                  "1. Remove a door\n" +
                                  "2. Add a door\n");

                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Console.Write("Enter badge id to remove a door: ");
                        int idToRemove = int.Parse(Console.ReadLine());
                        Console.Write("Enter a door to remove access: ");
                        if (_badgeRepo.RemoveDoor(idToRemove, Console.ReadLine()))
                            Console.WriteLine("Door removed!");
                        else
                            Console.WriteLine("Door is not removed");
                        break;
                    case '2':
                        Console.Write("Enter badge id to add a door: ");
                        int idToAdd = int.Parse(Console.ReadLine());
                        Console.Write("Enter a door to add access: ");
                        if (_badgeRepo.AddDoor(idToAdd, Console.ReadLine()))
                            Console.WriteLine("Door added!");
                        else
                            Console.WriteLine("Door is not added");
                        break;
                    default:
                        Console.Clear();
                        UpdateDoorsInBadge();
                        break;
                }
            }
            else
            {
                Console.WriteLine("There are no badges to update");
            }
        }
        private void DeleteDoorsFromBadge()
        {
            if (_badgeRepo.GetBadges.Count > 0)
            {
                Console.WriteLine("DELETING ALL DOORS FROM A BADGE\n");
                ShowAllBadges();
                Console.WriteLine();
                Console.Write("Enter Badge ID:");
                int id = int.Parse(Console.ReadLine());

                if (_badgeRepo.DeleteAllDoors(id))
                    Console.WriteLine("Doors successfully removed");
                else
                    Console.WriteLine("No doors removed!");
            }
            else
                Console.WriteLine("There are no badges to remove doors from!");
        }
        private void ShowAllBadges()
        {
            if(_badgeRepo.GetBadges.Count > 0)
            {
                Console.Write("BadgeID    ");
                int col_DoorAccess = Console.CursorLeft;
                Console.Write("DoorAccess\n");
                foreach (var badge in _badgeRepo.GetBadges.Values)
                {
                    Console.Write(badge.ID);
                    Console.CursorLeft = col_DoorAccess;
                    foreach (var door in badge.Doors)
                    {
                        Console.Write(door + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("There are no badges to show!");
            }
        }
        private void ReturnToMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Press Enter to return to menu");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                GetUserResponse();
            else
                ReturnToMenu();
        }
    }
}
