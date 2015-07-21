using System;

namespace DarkerSmile
{
    /// <summary>
    ///     Auto Null Checks Action Calls
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        ///     Activates action if it is not Null
        /// </summary>
        public static void Fire(this Action action)
        {
            if (action.Exists()) action();
        }

        /// <summary>
        ///     Activates action if it is not Null
        /// </summary>
        public static void Fire<T>(this Action<T> action, T item)
        {
            if (action.Exists()) action(item);
        }

        /// <summary>
        ///     Activates action if it is not Null
        /// </summary>
        public static T Fire<T>(this Func<T> action)
        {
            return action.Exists() ? action() : default(T);
        }

        /// <summary>
        ///     Activates action if it is not Null
        /// </summary>
        public static TX Fire<T, TX>(this Func<T, TX> action, T item)
        {
            return (action.Exists()) ? action(item) : default(TX);
        }
    }
}