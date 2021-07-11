using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public interface IMenuRepository
    {
        bool CreateMenuItem(MenuItem item);
        ICollection<MenuItem> GetMenu();
        bool DeleteMenuItem(int id);
    }
}
