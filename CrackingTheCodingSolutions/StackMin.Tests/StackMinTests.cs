using System;
using System.Linq;
using AutoFixture;
using Common.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackMin.Tests
{
    [TestClass]
    public class StackMinTests
    {
        private StackMin stack;
        private Fixture fixture;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackMin();
            fixture = new Fixture();
        }

        [TestMethod]
        public void StackMin_ShouldReturnCorrectMinValue()
        {
            var numberOfLayers = 10;
            var data = fixture.CreateMany<int>(numberOfLayers).ToList();

            foreach (var item in data)
                stack.Push(item);

            Assert.AreEqual(data.Min(), stack.Min());
        }

        [TestMethod]
        public void StackMin_ShouldRemoveMinValues_AfterPoppingThemOut()
        {
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            Assert.AreEqual(1, stack.Min());

            stack.Pop();
            Assert.AreEqual(2, stack.Min());

            stack.Pop();
            Assert.AreEqual(3, stack.Min());
        }
    }
}
