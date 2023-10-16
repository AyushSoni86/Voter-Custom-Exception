using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExceptionHandling5
{
    internal class Program
    {
        public static void Main()
        {
            // Specify the path to your JSON file
            string filePath = "C:\\Users\\ayush.soni\\source\\repos\\VoterCustomException\\ExceptionHandling5\\person.json";

            // Read the JSON content from the file
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON into a C# object
            var jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<Person>>>(json);

            // Access the data
            List<Person> people = jsonData["people"];

            foreach (var person in people)
            {
                try
                {
                    person.setAge(person.Birthdate);
                    person.canVote(person.getAge());
                }
                catch (UnderageVoterException ex)
                {
                    string path = "C:\\Users\\ayush.soni\\source\\repos\\VoterCustomException\\ExceptionHandling5\\" + DateTime.Now.ToString("dd MMM yyyy hh mm tt") + ".log";
                    using (StreamWriter stm = new StreamWriter(path, true))
                    {
                        stm.WriteLine("Name = " + person.Name + ",\t\t" +
                                    "Age = " + person.getAge() + "\t\t" +
                                    DateTime.Now + "\n" +
                                    ex.Message + "\n" +
                                    "------------------------------------------------------------------------------------");
                    }
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}