using System;
using System.Collections.Generic;
using System.Linq;

namespace ListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            var contact1 = new Contact("Kate", 457894563, "kate@test.com");
            var contact2 = new Contact("Kate", 457894563, "kate@test.com");
            var contact3 = new Contact("John", 457894777, "john@test.com");

            AddUnique(contact1, phoneBook);
            AddUnique(contact2, phoneBook);
            AddUnique(contact3, phoneBook);

            phoneBook.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));

            foreach (var contact in phoneBook)
            {
                Console.WriteLine($"{contact.Name}: {contact.PhoneNumber}: {contact.Email}");
            }

            Console.ReadKey();
        }

        static void AddUnique(Contact newContact, List<Contact> phoneBook)
        {
            if (phoneBook.Any())
            {
                foreach (var contact in phoneBook)
                {
                    if (contact.Email == newContact.Email)
                    {
                        return;
                    }
                }
            }

            phoneBook.Add(newContact);
        }
    }
}
