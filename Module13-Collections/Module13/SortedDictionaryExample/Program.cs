using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortedDictionaryExample
{
    class Program
    {
        private static SortedDictionary<string, Contact> SortedPhoneBook = new SortedDictionary<string, Contact>()
        {
            ["Игорь"] = new Contact(79990000000, "igor@example.com"),
            ["Андрей"] = new Contact(79990000001, "andrew@example.com"),
            ["Павел"] = new Contact(79990000002, "paul@example.com"),
            ["Александр"] = new Contact(79990000003, "alex@example.com"),
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Текущий список сортированных контактов: ");
            WriteAllSortedContacts();

            /*Сравнить производительность вставки нового значения для Словаря и Сортированного словаря.*/
            var stopWatch = Stopwatch.StartNew();
            SortedPhoneBook.TryAdd("Михаил", new Contact(79160000004, "michael@example.com"));
            Console.WriteLine($"Вставка в сортированный словарь заняла: {stopWatch.Elapsed.TotalMilliseconds} мс.");
            Console.WriteLine();

            Console.WriteLine("Обновленный список контактов: ");
            WriteAllSortedContacts();

            if (SortedPhoneBook.TryGetValue("Михаил", out Contact contact))
                contact.PhoneNumber = 375290000000;

            Console.WriteLine("Список после изменения: ");
            WriteAllSortedContacts();

            Console.ReadKey();
        }

        public static void WriteAllSortedContacts()
        {
            foreach (var contact in SortedPhoneBook)
                Console.WriteLine($"{contact.Key}: {contact.Value.PhoneNumber}");
            Console.WriteLine();
        }
    }
}
