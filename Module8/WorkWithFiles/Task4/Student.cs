using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Student()
        {

        }
        public Student(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }
}
