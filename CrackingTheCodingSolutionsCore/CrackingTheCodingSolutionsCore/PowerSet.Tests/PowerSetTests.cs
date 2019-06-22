using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerSet.Tests
{
    [TestClass]
    public class PowerSetTests
    {
        private Fixture fixture;

        [TestInitialize]
        public void Initialize()
        {
            fixture = new Fixture();
        }

        [TestMethod]
        public void PowerSet_ShouldReturnAllSubSets()
        {
            var elements = new List<int>() { 1, 2, 3 };
            var powerSet = new PowerSet(elements);

            var result = powerSet.GetAllSubsets();
            Assert.AreEqual(7, result.Count());
        }

        [TestMethod]
        public void PowerSet_ShouldReturnAllSubSets_ForHugeExample()
        {
            var elements = fixture.CreateMany<int>(10).ToList();
            var powerSet = new PowerSet(elements);

            var result = powerSet.GetAllSubsets();

            var expected = Math.Pow(2, elements.Count) - 1;
            Assert.AreEqual(expected, result.Count);
        }
    }
}
