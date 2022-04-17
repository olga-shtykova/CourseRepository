using System;
using System.Collections.Generic;
using System.Linq;

namespace Module14
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var numsList = new List<int[]>()
            {
               new[] {2, 3, 7, 1},
               new[] {45, 17, 88, 0},
               new[] {23, 32, 44, -6},
            };

            var orderedNums = numsList.SelectMany(s => s).OrderBy(s => s);

            foreach (var item in orderedNums)
                Console.WriteLine(item);

            Console.WriteLine();

            var companies = new Dictionary<string, string[]>();

            companies.Add("Apple", new[] { "Mobile", "Desktop" });
            companies.Add("Samsung", new[] { "Mobile" });
            companies.Add("IBM", new[] { "Desktop" });

            //var mobileComp = from comp in companies
            //             where comp.Value.Contains("Mobile")
            //             select comp;

            var mobileComp = companies.Where(c => c.Value.Contains("Mobile"));

            foreach (var item in mobileComp)
                Console.WriteLine(item.Key);
            */

            
            var students = new List<Student>
            {
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
               new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var selectedStudents = students
                .SelectMany(
                // коллекция, которую нужно преобразовать
                s => s.Languages,
                // функция преобразования, применяющаяся к каждому элементу коллекции
                (s, l) => new { Student = s, Lang = l })
                // дополнительные условия                          
                .Where(s => s.Lang == "английский" && s.Student.Age < 28)
                // указатель на объект выборки
                .Select(s => s.Student);

            // Выведем результат
            foreach (Student student in selectedStudents)
                Console.WriteLine($"{student.Name} - {student.Age}");

            //var studentApplications = from s in students
            //    // создадим анонимный тип для представления анкеты
            //    select new
            //    {
            //        FirstName = s.Name,
            //        YearOfBirth = DateTime.Now.Year - s.Age
            //    };

            var studentApplications = students.Select(s =>
                new
                {
                    FirstName = s.Name,
                    YearOfBirth = DateTime.Now.Year - s.Age,
                });

            // Выведем результат
            foreach (var application in studentApplications)
                Console.WriteLine($"{application.FirstName}, {application.YearOfBirth}");

            var fullNameStudents = from s in students
                                   // временная переменная для генерации полного имени
                                   let fullName = s.Name + "Иванов"
                                   // временная переменная для генерации полного имени
                                   select new
                                   {
                                       Name = fullName,
                                       Age = s.Age,
                                   };

            foreach (var stud in fullNameStudents)
                Console.WriteLine(stud.Name + ", " + stud.Age);

            /*
            string[] text = { "Раз два три", "четыре пять шесть", "семь восемь девять" };

            var words = from str in text // пробегаемся по элементам массива
                        from word in str.Split(' ') // дробим каждый элемент по пробелам, сохраняя в новую последовательность
                        select word; // собираем все куски в результирующую выборку

            foreach (var word in words)
                Console.WriteLine(word);
            */

            /*
            var Countries = new Dictionary<string, List<City>>();

            var russianCities = new List<City>()
            {
                new City("Москва", 11900000),
                new City("Санкт-Петербург", 4991000),
                new City("Волгоград", 1099000),
                new City("Казань", 1169000),
                new City("Севастополь", 449138),
            };

            var belarusCities = new List<City>()
            {
                new City("Минск", 1200000),
                new City("Витебск", 362466),
                new City("Гродно", 368710),
            };

            var americanCities = new List<City>()
            {
                new City("Нью-Йорк", 8399000),
                new City("Вашингтон", 705749),
                new City("Альбукерке", 560218),
            };

            Countries.Add("Россия", russianCities);
            Countries.Add("Беларусь", belarusCities);
            Countries.Add("США", americanCities);

            var megaCities = from country in Countries
                            from city in country.Value
                            where city.Population > 1000000
                            orderby city.Population descending
                            select city;

            foreach (var city in megaCities)
                Console.WriteLine(city.Name + " - " + city.Population);
            */

            /*
            var objects = new List<object>() { 1, "Сергей ", "Андрей ", 300, };

            var names = from o in objects
                        where o is string
                        orderby o
                        select o;

            foreach (var name in names)
                Console.WriteLine(name);

            foreach (var name in objects.Where(o => o is string).OrderBy(o => o))
                Console.WriteLine(name);
            */

            /*
            var people = new string[] { "Ann", "Mary", "Serge", "Alex", "David", "Ian" };

            // LINQ expressions
            var selectedPeople = from p in people
                                where p.StartsWith("A")
                                orderby p
                                select p;

            // LINQ extensions
            //var selectedPeople = people.Where(x => x.StartsWith("A")).OrderBy(p => p);

            foreach (var person in selectedPeople)
            {
                Console.Write($"{person} ");
            }
            */

            Console.ReadKey();
        }
    }
}
