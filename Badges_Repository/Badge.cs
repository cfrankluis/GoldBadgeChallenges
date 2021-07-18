using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class Badge
    {
        public int ID { get; }
        public List<string> Doors { get; set; }
        public string Name { get; set; }
        public Badge(int id){ ID = id; }
        public Badge(int iD, List<string> doors, string name)
        {
            ID = iD;
            Doors = doors;
            Name = name;
        }
    }
}
