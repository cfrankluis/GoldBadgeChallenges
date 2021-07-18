using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public enum ClaimType { Car, Home, Theft}
    public class Claim
    {
        public int ID { get; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public Claim(){}
        public Claim(int iD, ClaimType type, string description, decimal amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ID = iD;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
