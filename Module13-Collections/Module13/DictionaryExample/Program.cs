using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DictionaryExample
{
    class Program
    {
        private static Dictionary<string, Contact> PhoneBook = new Dictionary<string, Contact>()
        {
            ["Игорь"] = new Contact(79990000000, "igor@example.com"),
            ["Андрей"] = new Contact(79990000001, "andrew@example.com"),
            ["Павел"] = new Contact(79990000002, "paul@example.com"),
            ["Александр"] = new Contact(79990000003, "alex@example.com"),
        };

        static void Main(string[] args)
        {
            /*
            var cities = new Dictionary<string, string[]>
            {
                { "Россия", new[] { "Москва", "Санкт-Петербург", "Волгоград", } },
                { "Украина", new[] { "Киев", "Львов", "Николаев", } },
                { "Беларусь", new[] { "Минск", "Витебск", "Гродно", } },
            };

            foreach (var citiesByCountry in cities)
            {
                Console.Write(citiesByCountry.Key + ": ");
                foreach (var city in citiesByCountry.Value)
                    Console.Write(city + " ");

                Console.WriteLine();
            }

            Console.WriteLine();

            var russianCities = cities["Россия"];
            Console.WriteLine("Города России:");
            foreach (var city in russianCities)
                Console.WriteLine(city);
            */
                        
            Console.WriteLine("Текущий список контактов: ");
            WriteAllContacts();

            /*Сравнить производительность вставки нового значения для Словаря и Сортированного словаря.*/
            var stopWatch = Stopwatch.StartNew();
            PhoneBook.TryAdd("Михаил", new Contact(79160000004, "michael@example.com"));
            Console.WriteLine($"Вставка в словарь заняла: {stopWatch.Elapsed.TotalMilliseconds} мс.");
            Console.WriteLine();

            Console.WriteLine("Обновленный список контактов: ");
            WriteAllContacts();

            if (PhoneBook.TryGetValue("Михаил", out Contact contact))
                contact.PhoneNumber = 375290000000;

            Console.WriteLine("Список после изменения: ");
            WriteAllContacts();

            Console.ReadKey();
        }

        public static void WriteAllContacts()
        {
            foreach (var contact in PhoneBook)
                Console.WriteLine($"{contact.Key}: {contact.Value.PhoneNumber}");
            Console.WriteLine();
        }
    }
}
