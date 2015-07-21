using System;
using System.Collections.Generic;
using System.Linq;

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
            if (items.Exists())
                foreach (var item in items)
                    if (!self.Contains(item))
                        self.Add(item);
        }

        /// <summary>
        ///     Removes a random element from the provided list and returns it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T TakeRandomOne<T>(this IList<T> source)
        {
            if (source.DoesNotExist()) throw new ArgumentNullException("source");
            var it = source.GetRandomOne();
            source.Remove(it);
            return it;
        }

        /// <summary>
        ///     Tries to Take a number of elements randomly from the provided list and return them.
        ///     Returns as many as there are elements in the source collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The list to take elements from</param>
        /// <param name="amount">The number of elements to take from the list</param>
        /// <returns></returns>
        public static IEnumerable<T> TakeRandomX<T>(this IList<T> source, int amount)
        {
            var items = new List<T>();
            while (amount > 0)
            {
                if (!source.Any()) return items;
                var newItem = source.TakeRandomOne();
                if (newItem != null) items.Add(newItem);
                amount--;
            }
            return items;
        }

        /// <summary>
        ///     Wraps the provided number to a valid element index in the provided list and returns that element.
        ///     E.g Listlength+2 will provide theList[1] etc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static T GetElementAtWrappedIndex<T>(this IList<T> source, int index)
        {
            if (source.DoesNotExist()) throw new ArgumentNullException("source");
            if (source.Empty()) return default(T);
            return source[index.AsClampedToListWrapped(source)];
        }
    }
}