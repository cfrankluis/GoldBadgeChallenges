using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Claims_Repository;

namespace Claims_Test
{
    [TestClass]
    public class ClaimRepoTest
    {
        ClaimTestRepo _testRepo;
        Claim _claimOne;
        Claim _claimTwo;

        [TestInitialize]
        public void Arrange()
        {
            _claimOne = new Claim(
                1, ClaimType.Car,
                "Car accident on 465.",
                400.00m,
                new DateTime(2018,4,25),
                new DateTime(2018, 4, 27),
                true);

            _claimTwo = new Claim(
                3, ClaimType.Theft,
                "Stolen pancakes.",
                4000.00m,
                new DateTime(2018, 4, 11),
                new DateTime(2018, 4, 12),
                false);

            _testRepo = new ClaimTestRepo();
            _testRepo._claims.Enqueue(_claimOne);
        }

        [TestMethod]
        public void AddClaimTest_IncreaseCount()
        {
            int count = _testRepo._claims.Count;
            _testRepo.AddClaim(_claimTwo);
            Assert.IsTrue(count < _testRepo._claims.Count);
        }

        [TestMethod]
        public void SeeAllClaimsTest_SameCount()
        {
            int expected = _testRepo._claims.Count;
            int actual = _testRepo.SeeAllClaims().Count;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void HandleClaimTest_DecreaseCount()
        {
            int count = _testRepo._claims.Count;
            _testRepo.HandleClaim();
            Assert.IsTrue(count > _testRepo._claims.Count);
        }
    }
}
