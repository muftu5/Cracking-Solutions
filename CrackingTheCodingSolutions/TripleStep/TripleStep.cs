using System.Collections.Generic;
using System.Linq;

namespace TripleStep
{
    /// <summary>
    /// A brute force way. More efficient way will come later.
    /// </summary>
    public class TripleStep
    {
        private readonly int _n;
        private int[] _availableSteps = { 1, 2, 3 };

        public TripleStep(int n)
        {
            _n = n;
        }

        public int GetNumberOfWays()
        {
            var wayCount = 0;
            var ways = new List<int>() { _n };

            while (ways.Any())
            {
                wayCount += ways.Count(x => x == 0);

                ways = ways
                    .SelectMany(x => _availableSteps
                        .Select(y => x - y)
                        .Where(z => z >= 0))
                    .ToList();
            }

            return wayCount;
        }
    }
}
