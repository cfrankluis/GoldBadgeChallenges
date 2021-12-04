using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claims_Repository;

namespace Claims_UI
{
    class ProgramUI
    {
        private readonly IClaimRepository _claimRepo;
        private const char _currency = '$';

        public ProgramUI(IClaimRepository repo)
        {
            _claimRepo = repo;
        }

        public void Run()
        {
            GetUserResponse();
        }

        private void GetUserResponse()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Komodo Insurance Claims Manager!\n" +
                "Please select from the following options:\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim");

            char response = Console.ReadKey().KeyChar;
            EvaluateUserResponse(response);
        }

        private void EvaluateUserResponse(char response)
        {
            switch (response)
            {
                case '1':
                    ShowAllClaims();
                    break;
                case '2':
                    DealWithClaim();
                    break;
                case '3':
                    AddNewClaim();
                    break;
                default:
                    GetUserResponse();
                    break;
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();

            Console.Write("Enter the claim id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the claim type(Car, Home, Theft): ");
            ClaimType claimType = GetClaimType();

            Console.Write("Enter a claim description: ");
            string description = Console.ReadLine();

            Console.Write($"Amount of Damage({_currency}): ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Date of Accident: ");
            DateTime dateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim: ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.Write("Is the claim valid?(y/n) ");
            bool isValid = GetBool();

            Claim claimToAdd = new Claim(id,claimType,description,amount,dateOfAccident,dateOfClaim,isValid);

            bool succeeded = _claimRepo.AddClaim(claimToAdd);
            if (succeeded)
                Console.WriteLine("Claim added");
            else
                Console.WriteLine("No claim was added");

            ReturnToMenu();
        }

        private void DealWithClaim()
        {
            Console.Clear();
            if (_claimRepo.SeeAllClaims().Count > 0)
            {
                Claim claimToHandle = _claimRepo.SeeAllClaims().Peek();
                Console.WriteLine($"ClaimID: {claimToHandle.ID}");
                Console.WriteLine($"Type: {claimToHandle.Type}");
                Console.WriteLine($"Description: {claimToHandle.Description}");
                Console.WriteLine($"Date Of Accident: {claimToHandle.DateOfIncident.ToShortDateString()}");
                Console.WriteLine($"Date of Claim: {claimToHandle.DateOfClaim.ToShortDateString()}");
                Console.WriteLine($"Valid: {claimToHandle.IsValid}");
                Console.Write("Do you want to deal with this claim now(y/n)?");
                if (GetBool())
                {
                    if (_claimRepo.HandleClaim())
                        Console.WriteLine("\nClaim Handled");
                    else
                        Console.WriteLine("\nClaim Not Handled");
                }
                else
                    GetUserResponse();
            }
            else
                Console.WriteLine("There are no claims to handle.");
                ReturnToMenu();
        }

        private void ShowAllClaims()
        {
            Console.Clear();
            if (_claimRepo.SeeAllClaims().Count > 0)
            {
                Console.Write("ClaimID  ");
                int col_ClaimType = Console.CursorLeft;
                Console.Write("ClaimType  ");
                int col_DateOfIncident = Console.CursorLeft;
                Console.Write("DateOfIncident  ");
                int col_DateOfClaim = Console.CursorLeft;
                Console.Write("DateOfClaim  ");
                int col_IsValid = Console.CursorLeft;
                Console.Write("isValid  ");
                int col_Amount = Console.CursorLeft;
                Console.Write("Amount     ");
                int col_Description = Console.CursorLeft;
                Console.Write("Description\n");

                foreach (var claim in _claimRepo.SeeAllClaims())
                {
                    Console.Write(claim.ID);
                    Console.CursorLeft = col_ClaimType;
                    Console.Write(claim.Type);
                    Console.CursorLeft = col_DateOfIncident;
                    Console.Write(claim.DateOfIncident.ToShortDateString());
                    Console.CursorLeft = col_DateOfClaim;
                    Console.Write(claim.DateOfClaim.ToShortDateString());
                    Console.CursorLeft = col_IsValid;
                    Console.Write(claim.IsValid);
                    Console.CursorLeft = col_Amount;
                    Console.Write($"{_currency}{claim.Amount}");
                    Console.CursorLeft = col_Description;
                    Console.Write(claim.Description + "\n");
                }
            }
            else
                Console.WriteLine("There are no claims to show!");

            ReturnToMenu();
        }

        private bool GetBool()
        {
            while(true)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case 'y': return true;
                    case 'n': return false;
                }
            }
        }

        private ClaimType GetClaimType()
        {
            while(true)
            {
                switch (Console.ReadLine().ToUpper())
                {
                    case "CAR": return ClaimType.Car;
                    case "HOME": return ClaimType.Home;
                    case "THEFT": return ClaimType.Theft;
                }
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
