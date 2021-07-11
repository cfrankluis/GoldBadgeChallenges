using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenuRepository repository = new MenuRepository();
            ProgramUI programUI = new ProgramUI(repository);
            programUI.Run();
        }
    }
}
