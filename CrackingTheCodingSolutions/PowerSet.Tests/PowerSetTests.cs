using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerSet.Tests
{
    [TestClass]
    public class PowerSetTests
    {
        [TestMethod]
        public void PowerSet_ShouldReturnAllSubSets()
        {
            var elements = new List<int>() { 1, 2, 3 };
            var powerSet = new PowerSet(elements);

            var result = powerSet.GetAllSubsets().ToList();
            Assert.AreEqual(7, result.Count());
        }
    }
}
