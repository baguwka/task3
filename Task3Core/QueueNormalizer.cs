using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3Core
{
    public class QueueNormalizer
    {
        /// <exception cref="TooMuchBribesException">Throws if bribes count greater than 2 for any person</exception>
        /// <exception cref="ArgumentNullException"></exception>
        public BribesResultWithBribes RestoreChaosQueue(int[] queue)
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));

            if (queue.Length <= 1)
                return BribesResultWithBribes.No(queue);

            var bribesCount = new List<int>();
            var modifiedQueue = queue.ToArray();

            for (var i = 1; i < modifiedQueue.Length; i++)
            {
                var initialPositionNum = modifiedQueue[i];
                var currentPositionNum = i + 1;
                var bribesNeeded = currentPositionNum - initialPositionNum;

                var isAheadOfQueue = bribesNeeded < 0;
                if (isAheadOfQueue)
                    continue;

                if (bribesNeeded == 0)
                    continue;

                if (bribesNeeded > 2)
                    throw new TooMuchBribesException("too much");

                bribesCount.Add(bribesNeeded);

                SwapItemNTimes(modifiedQueue, i, bribesNeeded);
            }

            return new BribesResultWithBribes(modifiedQueue, bribesCount);
        }

        private void SwapItemNTimes(int[] queue, int indexToSwap, int numberOfSwaps)
        {
            if (numberOfSwaps > indexToSwap)
                throw new InvalidOperationException("Number of swaps can't be larger than index");

            for (int i = 0; i < numberOfSwaps; i++)
            {
                var toSwap = queue[indexToSwap - 1];
                queue[indexToSwap - 1] = queue[indexToSwap];
                queue[indexToSwap] = toSwap;
                indexToSwap--;
            }
        }
    }
}