using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly Dictionary<int,MenuItem> _menu = new Dictionary<int, MenuItem>();
        

        public bool CreateMenuItem(MenuItem item)
        {
            if (!_menu.ContainsValue(item))
            {
                int startCount = _menu.Count;
                _menu.Add(item.Id, item);
                return _menu.Count > startCount;
            }

            return false;
        }

        public ICollection<MenuItem> GetMenu()
        {
            return _menu.Values;
        }

        public bool DeleteMenuItem(int id)
        {
            return _menu.Remove(id);
        }
    }
}
