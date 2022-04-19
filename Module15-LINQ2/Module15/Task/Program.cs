using System;
using System.Collections.Generic;
using System.Linq;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
            {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
            };

            var allStudents = GetAllStudents(classes);

            Console.WriteLine(string.Join(" ", allStudents));
        }

        static string[] GetAllStudents(Classroom[] classes)
        {
            var allStudents = new List<string>();
            var students = classes.Select(student => student.Students).ToList();

            foreach (var names in students)
            {
                foreach (var name in names)
                {
                    allStudents.Add(name);
                }
            }

            return allStudents.ToArray();
        }

        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}
