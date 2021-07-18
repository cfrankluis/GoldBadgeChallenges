using System.Collections.Generic;

namespace Claims_Repository
{
    public interface IClaimRepository
    {
        bool AddClaim(Claim claim);
        bool HandleClaim();
        Queue<Claim> SeeAllClaims();
    }
}