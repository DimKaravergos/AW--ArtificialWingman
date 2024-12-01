using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlPickuper
{
    internal class Classes
    {
        public static void PrintSlowly(string text, int delayMilliseconds)
        {
            foreach (char c in text)
            {
                Console.Write(c); // Print character without newline
                Thread.Sleep(delayMilliseconds); // Delay in milliseconds
            }
            Console.WriteLine();
        }

        public static void AskQuestion(string question, string yesResponse, string noResponse)
        {
            string response;
            do
            {
                PrintSlowly(question, 30);
                response = Console.ReadLine();
            } while (response != "y" && response != "n");

            if (response == "y")
            {
                PrintSlowly(yesResponse, 30);
            }
            else
            {
                PrintSlowly(noResponse, 30);
            }
        }
    }
}