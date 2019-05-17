using System.Collections.Generic;
using System.Linq;

namespace Task3Core
{
    public class BribesResultWithBribes
    {
        public ICollection<int> AllBribes { get; }
        public int TotalBribes => AllBribes?.Sum() ?? 0;
        public int[] ResultQueue { get; }

        public BribesResultWithBribes(int[] resultQueue, ICollection<int> allBribes)
        {
            ResultQueue = resultQueue;
            AllBribes = allBribes;
        }

        public static BribesResultWithBribes No(int[] initialQueue) => new BribesResultWithBribes(initialQueue, new List<int>());
    }
}