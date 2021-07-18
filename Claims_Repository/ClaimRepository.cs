using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly Queue<Claim> _claims = new Queue<Claim>();

        public bool AddClaim(Claim claim)
        {
            _claims.Enqueue(claim);
            return _claims.Contains(claim);
        }
        public bool HandleClaim()
        {
            if (_claims.Count > 0)
            {
                int count = _claims.Count;
                _claims.Dequeue();
                return count > _claims.Count;
            }
            else
                return false;
        }
        public Queue<Claim> SeeAllClaims()
        {
            return _claims;
        }
    }
}
