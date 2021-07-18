using System.Collections.Generic;

namespace Badges_Repository
{
    public interface IBadgeRepository
    {
        Dictionary<int, Badge> GetBadges { get; }
        bool AddDoor(int id, string door);
        bool CreateBadge(Badge badge);
        bool DeleteAllDoors(int id);
        bool RemoveDoor(int id, string door);
    }
}