using CafeRepository.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository.REPOs
{
    public class MenuRepository : IMenuRepository
    {
        private readonly Dictionary<int,MenuItem> _menu = new Dictionary<int, MenuItem>();

        public bool CreateMenuItem(MenuItem item)
        {
            _menu.Add(item.Id, item);
            return _menu.ContainsValue(item);
        }

        public Dictionary<int, MenuItem> GetMenu()
        {
            return _menu;
        }

        public bool DeleteMenuItem(int id)
        {
            return _menu.Remove(id);
        }
    }
}
