using System.Collections.Generic;

namespace DarkerSmile
{
    /// <summary>
    /// Checks object Existence
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns true if the object is not null
        /// </summary>
        public static bool Exists(this object o)
        {
            return o != null;
        }

        /// <summary>
        /// Performs Equality Comparison on Generic Element.
        /// Returns true if element is equal to it's default state.
        /// </summary>
        /// <typeparam name="T">Type to check null state of</typeparam>
        /// <param name="a">Item to check</param>
        /// <returns></returns>
        public static bool NullOrDefault<T>(this T a)
        {
            return EqualityComparer<T>.Default.Equals(a, default(T));
        }
    }
}
