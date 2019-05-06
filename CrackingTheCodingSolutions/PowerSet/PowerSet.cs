using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSet
{
    public class PowerSet
    {
        private List<int> array;

        public PowerSet(List<int> list)
        {
            array = list;
        }

        public IEnumerable<IList<int>> GetAllSubsets()
        {
            var prevLayer = new List<SubSet>() { new SubSet(array) };
            IList<SubSet> result = new List<SubSet>() { prevLayer.First() };

            foreach (var i in Enumerable.Range(0, array.Count - 1))
            {
                var newLayer = new List<SubSet>();

                foreach (var subset in prevLayer)
                    newLayer = newLayer.Concat(GetSmallerSubsets(subset.Values)).ToList();

                prevLayer = newLayer.Distinct().ToList();
                result = result.Concat(prevLayer).ToList();
            }

            return result.Select(x => x.Values).ToList();
        }

        private IEnumerable<SubSet> GetSmallerSubsets(IList<int> list)
        {
            if (list == null || !list.Any())
                yield return null;

            foreach (var i in Enumerable.Range(0, list.Count))
            {
                var orderedSubset = list.Where((x, j) => j != i).OrderBy(x => x).ToList();
                yield return new SubSet(orderedSubset);
            }
        }

        private class SubSet : IEquatable<SubSet>
        {
            private readonly IList<int> list;

            public SubSet(IList<int> list)
            {
                this.list = list.ToList();
            }

            public bool Equals(SubSet other)
                => Values.SequenceEqual(other.Values);

            public override bool Equals(object obj)
            {
                if (obj is SubSet)
                    return Equals(obj as SubSet);

                return base.Equals(obj);
            }

            public override int GetHashCode()
                => list.Select(x => x.GetHashCode()).Aggregate((a, b) => a * 17 + b);

            public IList<int> Values => list;
        }
    }
}
