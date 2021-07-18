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
            Console.WriteLine("Please select from the following options:\n" +
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

            Console.Write("Enter the claim type: ");
            ClaimType claimType = GetClaimType(Console.ReadLine());

            Console.Write("Enter a claim description: ");
            string description = Console.ReadLine();

            Console.Write("Amount of Damage: ");
            decimal amount = decimal.Parse(Console.ReadLine().Remove(0,1));

            Console.Write("Date of Accident: ");
            DateTime dateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim: ");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.Write("Is the claim valid?(y/n) ");
            bool isValid = GetBool(Console.ReadKey().KeyChar);

            Claim claimToAdd = new Claim(id,claimType,description,amount,dateOfAccident,dateOfClaim,isValid);

            bool succeeded = _claimRepo.AddClaim(claimToAdd);

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
                if (GetBool(Console.ReadKey().KeyChar))
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
                int rClaimType = Console.CursorLeft;
                Console.Write("ClaimType  ");
                int rDateOfIncident = Console.CursorLeft;
                Console.Write("DateOfIncident  ");
                int rDateOfClaim = Console.CursorLeft;
                Console.Write("DateOfClaim  ");
                int rIsValid = Console.CursorLeft;
                Console.Write("isValid  ");
                int rAmount = Console.CursorLeft;
                Console.Write("Amount     ");
                int rDescription = Console.CursorLeft;
                Console.Write("Description\n");

                foreach (var claim in _claimRepo.SeeAllClaims())
                {
                    Console.Write(claim.ID);
                    Console.CursorLeft = rClaimType;
                    Console.Write(claim.Type);
                    Console.CursorLeft = rDateOfIncident;
                    Console.Write(claim.DateOfIncident.ToShortDateString());
                    Console.CursorLeft = rDateOfClaim;
                    Console.Write(claim.DateOfClaim.ToShortDateString());
                    Console.CursorLeft = rIsValid;
                    Console.Write(claim.IsValid);
                    Console.CursorLeft = rAmount;
                    Console.Write($"${claim.Amount}");
                    Console.CursorLeft = rDescription;
                    Console.Write(claim.Description + "\n");
                }
            }
            else
                Console.WriteLine("There are no claims to show!");

            ReturnToMenu();
        }

        private bool GetBool(char response)
        {
            while(true)
            {
                switch (response)
                {
                    case 'y': return true;
                    case 'n': return false;
                }
            }
        }

        private ClaimType GetClaimType(string type)
        {
            switch(type.ToUpper())
            {
                case "CAR": return ClaimType.Car;
                case "HOME": return ClaimType.Home;
                case "THEFT": return ClaimType.Theft;
                default: return (ClaimType)5;
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
