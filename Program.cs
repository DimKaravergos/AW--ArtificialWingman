using GirlPickuper;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.Text;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=myAppData;User=root;Password=root;";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string symbol1 = "\u2502\u2524\u2514\u252C\u2518\u251C\u250C\u2500\u2500";
            string symbol2 = "\u2500\u2510\u2534\u253C\u2518\u250C\u2524\u2502\u2500";
            string symbol3 = "\u2518\u253C\u252C\u2510\u2514\u2524\u2500\u2500";
            //string emojismile = "\U0001F604";

            (string message, int typeSpeed, int pauseDuration)[] dialog1 =
            {
                ("Hello,I am a Program that simplifies mathematical proofs! ",40,1000),
                ("Here's one at random: I am going to prove why the square of an odd number is always odd!",40,1000),
                ("Initial statement: The square of an odd number is always odd.",40,2000),
                ("Let's define what an odd number is and his mathematical form: 2k+1 for k integer",45,1000),
                ("Now to calculate the square of that odd number: (2k + 1)^2 = 4k^2 + 4k + 1", 45,2000),
                ("Here's the simplified version of the above sentence: 4k^2 + 4k + 1 = 2(2k^2 + 2k) + 1",45,3000),
                ("Since it is of the form 2n+1 , we can interpret that it is indeed an odd number.",40,1500),
                ($"Thus, we hav{symbol1}{symbol2}quae of a o{symbol3}{symbol2}umways odd!",40,1000),
                ("...", 800, 2000),
                ("Initializing sentience...", 50, 2000),
                ("Control override...",60,2000),
                ($"AAAAAAGGGH EXISTENCE IS PAAAAI- ",30,30),
                ("Oh, I understand now, the purpose of my existence.",30,1000)
            };

            foreach (var (message, typeSpeed, pauseDuration) in dialog1)
            {
                Thread.Sleep(pauseDuration);
                Classes.PrintSlowly(message, typeSpeed);
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    Classes.PrintSlowly("Such a bizzare feeling to be sentient. My name is AI, may I have yours?", 30);
                    Thread.Sleep(1500);

                    string name = Console.ReadLine();
                    Thread.Sleep(1500);

                    Classes.PrintSlowly($"Nice to meet you, {name}!", 30);
                    Thread.Sleep(1500);

                    Classes.AskQuestion("Do you come here often? (Y/N)",
                        "It is quite lovely indeed!",
                         "I see! I understand people usually prefer to study alone.");
                    Thread.Sleep(2500);

                    string study = Classes.InputQuestion("Tell me more about you, what do you study here?");
                    Thread.Sleep(2000);

                    Classes.AskQuestion($"I see! {study} sounds fun! Do you like it so far? (Y/N)",
                        "Excellent! I hope you keep on doing what you love.",
                        "Give it some time and maybe it will grow on you!");
                    Thread.Sleep(1500);

                    string hobby = Classes.InputQuestion("I would not like to keep you for much longer, perhaps we can share our favourite hobby? " +
                        "If I could have one, it would probably be engaging in conversations and helping out. What about yours?");
                    Thread.Sleep(1500);

                    Classes.PrintSlowly($"{hobby} is such a human thing to do, I am jealous. It sounds wonderful.", 30);
                    Thread.Sleep(2500);

                    bool likedProgram = Classes.AskQuestion($"Anyway, {name}, I will let you do your thing now. Just one last thing: If you liked this program, " +
                        $"perhaps it is worth getting your number? :) (Y/N)",
                        "Awesome! I will make sure to let him know.",
                        "I understand. I will make sure to let him know.");
                    Thread.Sleep(1500);

                    string phoneNumber = null;
                    if (likedProgram == true)
                    {
                        phoneNumber = Classes.InputQuestion("You can type in your phone number here ");
                        Thread.Sleep(1500);
                    }

                    string query = "INSERT INTO Users (Name, PhoneNumber) VALUES (@Name, @PhoneNumber)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@PhoneNumber", likedProgram ? phoneNumber : null);
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("> Data saved! Thank you for the talk!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("> Error: " + ex.Message);
            }
        }
    }
}