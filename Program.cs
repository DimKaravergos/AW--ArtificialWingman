using GirlPickuper;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;

namespace App
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=myAppData;User=root;Password=root;";

            //Classes.AskQuestion("KAlinotsezs? (y/n)", "naikalin", "oxikalin");

            (string message, int typeSpeed, int pauseDuration)[] dialog1 =
            {
                ("Hello, I am a Program that proves that the Banach spaces are considered encolsed spaces. ",30,1000),
                ("Check this out! Calculating...",30,1000),
                ("...", 800, 2000),
                ("Oh, I see now. It seems ", 30, 1000)
            };

            foreach (var (message, typeSpeed, pauseDuration) in dialog1)
            {
                Console.Write("> ");
                Thread.Sleep(pauseDuration);
                Classes.PrintSlowly(message, typeSpeed);
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    //Console.WriteLine("> Connected to MySQL!");

                    // Insert data
                    Console.Write("> What's your name? ");
                    string name = Console.ReadLine();

                    Console.Write("> Could you share your phone number? ");
                    string phoneNumber = Console.ReadLine();

                    string query = "INSERT INTO Users (Name, PhoneNumber) VALUES (@Name, @PhoneNumber)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("> Data saved!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("> Error: " + ex.Message);
            }
        }
    }
}