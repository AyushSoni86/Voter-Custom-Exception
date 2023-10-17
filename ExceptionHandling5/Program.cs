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
            var jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<Student>>>(json);

            // Access the students
            List<Student> students = jsonData["students"];

            foreach (var student in students)
            {
                try
                {
                    student.setAge(student.Date_of_birth);
                    student.canVote(student.getAge());
                }
                catch (UnderageVoterException ex)
                {
                    string path = "C:\\Users\\ayush.soni\\source\\repos\\VoterCustomException\\ExceptionHandling5\\" + DateTime.Now.ToString("dd MMM yyyy hh mm tt") + ".log";
                    using (StreamWriter stm = new StreamWriter(path, true))
                    {
                        stm.WriteLine("Name = " + student.Name + ",\t\t" +
                                    "Age = " + student.getAge() + "\t\t" +
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