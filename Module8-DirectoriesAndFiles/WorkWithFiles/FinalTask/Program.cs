using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var newDirectory = new DirectoryInfo(@"C:\Users\july2\Desktop\Students");
            if (!newDirectory.Exists)
                newDirectory.Create();

            var filePath = @"C:\Users\july2\Desktop\Students.dat";

            var students = new List<Student>();

            if (File.Exists(filePath))
            {
                try
                {
                    var formatter = new BinaryFormatter();
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                        var data = (Student[])formatter.Deserialize(stream);
                        foreach (var student in data)
                        {
                            Console.WriteLine(student.Name);
                            Console.WriteLine(student.Group);
                            Console.WriteLine(student.DateOfBirth.ToShortDateString());

                            students.Add(student);
                        }
                    }

                    var groups = students.Select(x => x.Group).Distinct().ToList();
                    foreach (var group in groups)
                    {
                        string studentFile = $@"C:\Users\july2\Desktop\Students\{group}.txt";

                        var studentsInGroup = students.Where(s => s.Group == group).ToList();

                        if (!File.Exists(studentFile))
                        {
                            using (StreamWriter sw = File.CreateText(studentFile))
                            {
                                foreach (var student in studentsInGroup)
                                {
                                    sw.WriteLine($"{student.Name}, {student.DateOfBirth}");
                                }                                    
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"The process failed {e.Message}.");
                }
            }
        }
    }
}
