using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkerSmile
{
    /// <summary>
    ///     Adds additional Filter and Sorting functionality to Enumerations
    /// </summary>
    public static class EnumerableExtensions
    {
        private static readonly Random R = new Random();

        /// <summary>
        ///     Converts an enumerable into a string in the format: '[A,B,C]'
        /// </summary>
        /// <typeparam name="T">Enumerated Type</typeparam>
        /// <param name="source">Enumeration collection source</param>
        /// <returns>Formatted String</returns>
        public static string ToDisplayString<T>(this IEnumerable<T> source)
        {
            if (source.DoesNotExist()) return "null";

            var s = "[";
            s = source.Aggregate(s, (res, x) => res + x.ToString() + ", ");
            return string.Format("{0}]", s.Substring(0, s.Length - 2));
        }

        /// <summary>
        ///     Returns a new list, omiting the first element of the source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> ButFirst<T>(this IEnumerable<T> source)
        {
            return source.Skip(1);
        }

        /// <summary>
        ///     Returns a new list, omiting the last element of the source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> ButLast<T>(this IEnumerable<T> source)
        {
            var lastX = default(T);
            var first = true;

            foreach (var x in source)
            {
                if (first) first = false;
                else yield return lastX;
                lastX = x;
            }
        }

        /// <summary>
        ///     Returns highest element in collection by provided comparitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static T MaxBy<T>(this IEnumerable<T> source, Func<T, IComparable> score)
        {
            return source.Aggregate((x, y) => score(x).CompareTo(score(y)) > 0 ? x : y);
        }

        /// <summary>
        ///     Returns lowest element in collection by provided comparitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static T MinBy<T>(this IEnumerable<T> source, Func<T, IComparable> score)
        {
            return source.Aggregate((x, y) => score(x).CompareTo(score(y)) < 0 ? x : y);
        }

        /// <summary>
        ///     Returns the provided enumerable with its indexes shifted one left
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> ShiftedLeft<T>(this IEnumerable<T> source)
        {
            var enumeratedList = source as IList<T> ?? source.ToList();
            return enumeratedList.ButFirst().Concat(enumeratedList.Take(1));
        }

        /// <summary>
        ///     Returns the provided enumerable with its indexes shifted one right
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> ShiftedRight<T>(this IEnumerable<T> source)
        {
            var enumeratedList = source as IList<T> ?? source.ToList();
            yield return enumeratedList.Last();

            foreach (var item in enumeratedList.ButLast())
            {
                yield return item;
            }
        }

        /// <summary>
        ///     Returns a random element from the provided enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T RandomOne<T>(this IEnumerable<T> source)
        {
            return source.GetRandomX(1).First();
        }

        /// <summary>
        ///     Returns a random X amount of elements from the collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source collection</param>
        /// <param name="amount">The Number of random elements to generate</param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomX<T>(this IEnumerable<T> source, int amount)
        {
            if (source == null) throw new ArgumentNullException("source");


            if (amount < 0) throw new ArgumentOutOfRangeException("amount");

            var samples = new List<T>();

            var i = 1;

            foreach (var item in source)
            {
                if (i <= amount) samples.Add(item);
                else
                {
                    var r = R.Next(0, i);
                    if (r < amount) samples[r] = item;
                }

                i++;
            }

            return samples;
        }

        /// <summary>
        ///     Returns the Enumerable in list form with its elements shuffled.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public static IList<T> ToListShuffled<T>(this IEnumerable<T> source)
        {
            if (source.DoesNotExist()) return new List<T>();
            var l = source.ToList();
            l.Shuffle();
            return l;
        }

        /// <summary>
        ///     Filters an Enumerable collection by the class or interface subtype
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TFilter"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TFilter> FilterByType<T, TFilter>(this IEnumerable<T> source)
            where T : class
            where TFilter : class, T
        {
            return source.Where(item => item as TFilter != null).Cast<TFilter>();
        }
    }
}