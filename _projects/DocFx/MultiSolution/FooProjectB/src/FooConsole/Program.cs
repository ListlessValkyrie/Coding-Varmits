using System;

namespace FooConsole
{
    internal class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("What a terrible application.".ToTimeStampedString());
        }
    }
}
