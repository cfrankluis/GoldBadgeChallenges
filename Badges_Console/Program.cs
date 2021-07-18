using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badges_Repository;

namespace Badges_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IBadgeRepository repository = new BadgeRepository();
            ProgramUI programUI = new ProgramUI(repository);
            programUI.Run();
        }
    }
}
