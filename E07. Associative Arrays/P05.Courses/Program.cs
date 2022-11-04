using System;
using System.Collections.Generic;

namespace P05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Key -> Value
            //Course Name -> List<Usernames>
            Dictionary<string, List<string>> coursesInfo =
                new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = cmdArgs[0];
                string studentName = cmdArgs[1];

                if (!coursesInfo.ContainsKey(courseName))
                {
                    //Never forget to instantiate Value (List, Array, Class, Dictionary)
                    coursesInfo[courseName] = new List<string>();
                }

                //Here we are sure that we already have created instance for the value
                coursesInfo[courseName].Add(studentName);
            }

            foreach (var kvp in coursesInfo)
            {
                string courseName = kvp.Key;
                List<string> students = kvp.Value;

                Console.WriteLine($"{courseName}: {students.Count}");
                foreach (string studentName in students)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}
