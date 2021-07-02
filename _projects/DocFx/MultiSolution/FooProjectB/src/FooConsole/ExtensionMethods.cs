using System;

namespace FooConsole
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Pre-appends string with time stamp.
        /// </summary>
        /// <param name="value">Input string.</param>
        /// <returns>Time stamped string.</returns>
        public static string ToTimeStampedString(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = string.Empty;
            }

            return $"{DateTime.Now.ToShortTimeString()} {value}";
        }
    }
}
