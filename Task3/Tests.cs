using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Task3Core;

namespace Task3.Testing
{
    public class Tests
    {
        public static IEnumerable<TestCaseData> QueueCases
        {
            get
            {
                return GetCases()
                    .Select(@case => new TestCaseData(@case.queue, @case.min));
            }
        }

        private static IEnumerable<(int[] queue, int? min)> GetCases()
        {
            yield return (new[] { 2, 1, 5, 3, 4 }, 3);
            yield return (new[] { 2, 5, 3, 1, 4 }, null);
            yield return (new[] { 5, 1, 2, 3, 7, 8, 6, 4 }, null);
            yield return (new[] { 1, 2, 5, 3, 7, 8, 6, 4 }, null);

            yield return (new[] { 1, 3, 2, 4, 5, 6, 7 }, 1);
            yield return (new[] { 1, 3, 5, 2, 4, 6, 7 }, 3);
            yield return (new[] { 1, 2, 3, 4, 5, 6, 7 }, 0);
            yield return (new[] { 7, 1, 2, 3, 4, 5, 6 }, 6);
        }

        [TestCaseSource(nameof(QueueCases))]
        public void CheckBribesCountToRestoreQueueTest(int[] queue, int? minBribesCount)
        {
            if (minBribesCount == null)
                Assert.Throws<TooMuchBribesException>(AssertBribesCount);
            else
                Assert.DoesNotThrow(AssertBribesCount);

            void AssertBribesCount()
            {
                var chaosQueue = new QueueNormalizer();
                var result = chaosQueue.RestoreChaosQueue(queue);

                var sortedQueue = queue
                    .OrderBy(i => i)
                    .ToArray();

                var isSorted = result.ResultQueue.SequenceEqual(sortedQueue);
                Assert.That(isSorted, Is.True, $"¬озвращен не отсортированный массив. {string.Join(",", result.ResultQueue)}");

                Assert.That(result.TotalBribes, Is.EqualTo(minBribesCount), "too much");
            }
        }
    }
}