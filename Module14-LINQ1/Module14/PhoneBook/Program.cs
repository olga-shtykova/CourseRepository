using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>()
            {
                new Contact("Леонид", "Агутин", 79990000001, "igor@example.com"),
                new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                new Contact("Иннокентий", "Смоктуновский", 799900000014, "innokentii@example.com"),
            };

            var sortedPhoneBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName);

            while (true)
            {
                var input = Console.ReadKey().KeyChar;

                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    var pageContent = sortedPhoneBook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();
                                        
                    foreach (var entry in pageContent)
                        //Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);
                        Console.WriteLine($"{entry.Name} {entry.LastName}: {entry.PhoneNumber}");

                    Console.WriteLine();
                }
            }
        }
    }
}
