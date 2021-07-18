using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claims_Repository;

namespace Claims_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IClaimRepository claimRepository = new ClaimRepository();
            ProgramUI programUI = new ProgramUI(claimRepository);
            programUI.Run();
        }
    }
}
