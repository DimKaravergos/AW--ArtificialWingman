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
            Console.Write("> ");
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds);
            }
            Console.WriteLine();
        }

        public static bool AskQuestion(string question, string yesResponse, string noResponse)
        {
            string response;
            do
            {
                PrintSlowly(question, 30);
                response = Console.ReadLine();
            } while (response != "y" && response != "n");

            if (response == "y")
            {
                Thread.Sleep(1500);
                PrintSlowly(yesResponse, 30);
                return true;
            }
            else
            {
                Thread.Sleep(1500);
                PrintSlowly(noResponse, 30);
                return false;
            }
        }

        public static string InputQuestion(string question)
        {
            string input;
            do
            {
                PrintSlowly(question, 30);
                input = Console.ReadLine()?.Trim();
                //Console.WriteLine($"input is {input}");

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintSlowly("> Input cannot be empty. Please try again.", 30);
                    continue;
                }

                break;
            } while (true);

            return input;
        }
    }
}