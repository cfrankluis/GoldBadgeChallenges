using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public class ClaimTestRepo
    {
        public readonly Queue<Claim> _claims = new Queue<Claim>();

        public bool AddClaim(Claim claim)
        {
            _claims.Enqueue(claim);
            return _claims.Contains(claim);
        }
        public bool HandleClaim()
        {
            int count = _claims.Count;
            _claims.Dequeue();
            return count > _claims.Count;
        }
        public Queue<Claim> SeeAllClaims()
        {
            return _claims;
        }
    }
}
