using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TripleStep.Tests
{
    [TestClass]
    public class TripleStepTests
    {
        [TestMethod]
        public void GetNumberOfWays_ShouldReturnCorrectResult_ForSmallExample()
        {
            var n = 3;
            var tripleStep = new TripleStep(n);

            var ways = tripleStep.GetNumberOfWays();

            var expectedResult = 4;
            Assert.AreEqual(expectedResult, ways);
        }
    }
}
