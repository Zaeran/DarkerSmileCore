using System;
using System.Collections.Generic;

namespace DarkerSmile
{
    public static class ListExtensions
    {
        private static readonly Random R = new Random();

        /// <summary>
        ///     Shuffles the elements in the provided list randomly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public static void Shuffle<T>(this IList<T> source)
        {
            var n = source.Count;

            while (n > 1)
            {
                n--;
                var k = R.Next(0, n + 1);
                var value = source[k];
                source[k] = source[n];
                source[n] = value;
            }
        }

        /// <summary>
        ///     Adds the unique new elements from the provided Enumerable into the existing list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="items"></param>
        public static void AddUnique<T>(this IList<T> self, IEnumerable<T> items)
        {
            if(items.Exists())
            foreach (var item in items)
                if (!self.Contains(item))
                    self.Add(item);
        }
    }
}