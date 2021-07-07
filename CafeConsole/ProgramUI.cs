using CafeRepository.REPOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsole
{
    class ProgramUI
    {
        private readonly IMenuRepository _repo;
        
        public ProgramUI(IMenuRepository repo)
        {
            _repo = repo;
        }

        public void Run()
        {

        }
    }
}
