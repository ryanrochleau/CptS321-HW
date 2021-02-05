using System;

namespace HW1
{
    class Program
    {
        /// <summary>
        /// Main function of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string inputString;

            inputString = Console.ReadLine();

            string[] subs = inputString.Split(' ');
            int[] inputIntegers = Array.ConvertAll(subs, int.Parse);

        }
    }
}
