using System;
using System.Collections.Generic;

namespace BDDfySamples.CustomFramework
{
    public static class Extensions
    {
        public static IEnumerable<T> Each<T>(this IEnumerable<T> values, Action<T> eachAction)
        {
            foreach (T item in values)
            {
                eachAction(item);
            }

            return values;
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> collection, int batchSize)
        {
            List<T> nextbatch = new List<T>(batchSize);
            foreach (T item in collection)
            {
                nextbatch.Add(item);
                if (nextbatch.Count == batchSize)
                {
                    yield return nextbatch;
                    nextbatch = new List<T>(batchSize);
                }
            }
            if (nextbatch.Count > 0)
                yield return nextbatch;
        }
    }
}