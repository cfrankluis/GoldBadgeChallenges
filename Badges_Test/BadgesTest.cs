using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Badges_Repository;

namespace Badges_Test
{
    [TestClass]
    public class BadgesTest
    {
        BadgesTestRepo _testRepo;
        Badge _badgeOne;
        Badge _badgeTwo;

        [TestInitialize]
        public void Arrange()
        {
            _badgeOne = new Badge(1);
            _badgeOne.Name = "Badge One";
            _badgeOne.Doors = new List<string>() { "A1","A4","B1","B2" };

            _badgeTwo = new Badge(2);
            _badgeTwo.Name = "Badge Two";
            _badgeTwo.Doors = new List<string>() { "A4", "A5", "A7" };

            _testRepo = new BadgesTestRepo();
            _testRepo._badges.Add(1,_badgeOne);
        }

        [TestMethod]
        public void CreateBadgeTest_IncreaseCount()
        {
            int countBeforeAct = _testRepo._badges.Count;
            _testRepo.CreateBadge(_badgeTwo);
            Assert.IsTrue(countBeforeAct < _testRepo._badges.Count);
        }

        [TestMethod]
        public void GetBadgesTest_SameObjectInstace()
        {
            var expected = _testRepo._badges;
            var actual = _testRepo.GetBadges;
            Assert.AreSame(actual, expected);
        }

        [TestMethod]
        public void DeleteAllDoorsTest_ZeroCountInDoorList()
        {
            _testRepo.DeleteAllDoors(1);
            Assert.AreEqual(_badgeOne.Doors.Count, 0);
        }

        [TestMethod]
        public void AddDoorTest_DoorCountIncrease()
        {
            int count = _badgeOne.Doors.Count;
            _testRepo.AddDoor(1,"B3");
            Assert.IsTrue(count < _badgeOne.Doors.Count);
        }

        [TestMethod]
        public void RemoveDoorTest_DoorCountDecrease()
        {
            int count = _badgeOne.Doors.Count;
            _testRepo.RemoveDoor(1, "A1");
            Assert.IsTrue(count > _badgeOne.Doors.Count);
        }

        
    }
}
