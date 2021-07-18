using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{
    public class BadgeRepository : IBadgeRepository
    {
        private readonly Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();

        public bool CreateBadge(Badge badge)
        {
            if (_badges.ContainsKey(badge.ID))
                return false;
            else
            {
                int countBeforeAdd = _badges.Count;
                _badges.Add(badge.ID, badge);
                return countBeforeAdd < _badges.Count;
            }
        }

        public Dictionary<int, Badge> GetBadges
        {
            get { return _badges; }
        }

        public bool DeleteAllDoors(int id)
        {
            _badges[id].Doors.Clear();
            return _badges[id].Doors.Count == 0;
        }

        public bool AddDoor(int id, string door)
        {
            if (_badges[id].Doors.Contains(door))
                return false;
            else
            {
                int countBeforeAdd = _badges[id].Doors.Count;
                _badges[id].Doors.Add(door);
                return countBeforeAdd < _badges[id].Doors.Count;
            }

        }

        public bool RemoveDoor(int id, string door)
        {
            return _badges[id].Doors.Remove(door);
        }
    }
}
