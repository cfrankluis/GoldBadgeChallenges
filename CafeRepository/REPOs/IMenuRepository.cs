using CafeRepository.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository.REPOs
{
    public interface IMenuRepository
    {
        bool CreateMenuItem(MenuItem item);
        Dictionary<int, MenuItem> GetMenu();
        bool DeleteMenuItem(int id);
    }
}
