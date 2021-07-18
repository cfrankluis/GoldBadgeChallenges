using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe_Repository;
using System;

namespace Cafe_Test
{
    [TestClass]
    public class CafeRepoTest
    {
        MenuRepoTest _testRepo;
        MenuItem _itemOne;
        MenuItem _itemTwo;

        [TestInitialize]
        public void Arrange()
        {
            _itemOne = new MenuItem(1);
            _itemTwo = new MenuItem(2);
            _testRepo = new MenuRepoTest();
            _testRepo._menu.Add(_itemOne.Id, _itemOne);
        }
        
        [TestMethod]
        public void CreateMenuItemTest_InreaseCount()
        {
            int count = _testRepo._menu.Count;
            _testRepo.CreateMenuItem(_itemTwo);
            Assert.IsTrue(count < _testRepo._menu.Count);
        }

        [TestMethod]
        public void GetMenuTest_SameCount()
        {
            int count = _testRepo._menu.Count;
            var repo = _testRepo.GetMenu();
            Assert.AreEqual(count, repo.Count);
        }

        [TestMethod]
        public void DeleteMenuItemTest_ReduceCount()
        {
            int count = _testRepo._menu.Count;
            _testRepo.DeleteMenuItem(_itemOne.Id);
            Assert.IsTrue(count > _testRepo._menu.Count);
        }
    }
}
