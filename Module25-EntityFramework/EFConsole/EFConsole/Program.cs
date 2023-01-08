using EFConsole.DAL;
using EFConsole.Models;
using System;
using System.Collections.Generic;

namespace EFConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                // Пересоздаем базу
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var author1 = new Author { Name = "Charlotte Bronte" };
                var author2 = new Author { Name = "Jane Austen" };
                var author3 = new Author { Name = "Philip Pullman" };
                var author4 = new Author { Name = "Jack London" };
                var author5 = new Author { Name = "Leo Tolstoy" };

                var book1 = new Book { Title = "Northern Lights", Year = 1995, };
                var book2 = new Book { Title = "Aelita", Year = 1923, };
                var book3 = new Book { Title = "Martin Eden", Year = 1909, };
                var book4 = new Book { Title = "Pride And Prejudice", Year = 1813, };
                var book5 = new Book { Title = "The Professor", Year = 1857, };

                book1.Author = author3;
                book2.Author = author5;
                book3.Author = author4;
                book4.Author = author2;
                book5.Author = author1;

                var genre1 = new Genre { Name = "Romance" };
                var genre2 = new Genre { Name = "Children" };
                var genre3 = new Genre { Name = "Fiction" };
                var genre4 = new Genre { Name = "Science fiction" };
                var genre5 = new Genre { Name = "Fantasy" };

                book1.Genres.AddRange(new[] { genre2, genre5 });
                book2.Genres.Add(genre4);
                book3.Genres.Add(genre3);
                book4.Genres.AddRange(new[] { genre1, genre3 });
                book5.Genres.AddRange(new[] { genre1, genre3 });

                var topic1 = new Topic { Name = "Topic 1" };
                var topic2 = new Topic { Name = "Topic 2" };
                var topic3 = new Topic { Name = "Topic 3" };

                var company1 = new Company { Name = "SF" };
                var company2 = new Company { Name = "VK" };
                var company3 = new Company { Name = "FB" };

                db.Companies.Add(company3);
                db.SaveChanges();

                var user1 = new User { Name = "Arthur Long", Email = "art@test.com", Role = "Admin" };
                var user2 = new User { Name = "Bob Jannings", Email = "bob@test.com", Role = "Admin" };
                var user3 = new User { Name = "Anna Сole", Email = "anna@test.com", Role = "User" };
                var user4 = new User { Name = "Derek Linch", Email = "derek@test.com", Role = "User" };

                user1.Company = company1;
                company2.Users.Add(user2);
                user3.CompanyId = company3.Id;
                user4.CompanyId = company3.Id;

                topic1.Users.AddRange(new[] { user3, user4 });
                topic2.Users.AddRange(new[] { user1, user2 });
                user1.Topics.AddRange(new[] { topic1, topic3 });

                var dateAndTime = DateTime.Now;
                var date = dateAndTime.Date;

                var annaBooks = new List<Subscription>
                {
                    new Subscription { Book = book1, StartDate = date },
                    new Subscription { Book = book2, StartDate = new DateTime(2022, 12, 10) },
                };
                user3.Subscriptions.AddRange(annaBooks);
                user4.Subscriptions.Add(new Subscription { Book = book3, StartDate = date });

                db.Companies.AddRange(company1, company2);
                db.Topics.AddRange(topic1, topic2, topic3);
                db.Authors.AddRange(author1, author2, author3, author4, author5);
                db.Books.AddRange(book1, book2, book3, book4, book5);
                db.Genres.AddRange(genre1, genre2, genre3, genre4);
                db.Users.AddRange(user1, user2, user3, user4);

                db.SaveChanges();

                var user1Creds = new UserCredential { Login = "ArthurL", Password = "qwerty123" };
                var user2Creds = new UserCredential { Login = "BobJ", Password = "asdfgh585" };
                var user3Creds = new UserCredential { Login = "AnnaС", Password = "111zlt777" };
                var user4Creds = new UserCredential { Login = "DerekL", Password = "zxc333vbn" };

                user1Creds.User = user1;
                user2Creds.UserId = user2.Id;
                user3.UserCredential = user3Creds;
                user4.UserCredential = user4Creds;

                // Не добавляем user1Creds в БД
                //db.UserCredentials.AddRange(user2Creds, user3Creds, user4Creds);

                db.UserCredentials.AddRange(user1Creds, user2Creds, user3Creds, user4Creds);

                db.SaveChanges();
            }

            using (var db = new AppContext())
            {
                var userRep = new UserRepository();
                var bookRep = new BookRepository();

                var users = userRep.GetUsersByCompanyId(1);

                foreach (var user in users)
                {
                    Console.WriteLine($"User: {user.Id} - {user.Name}");
                    Console.WriteLine("-------------------");
                }

                var amountOfBooksUserHolds = bookRep.GetAmountOfBooksInHoldByUserId(2);
                Console.WriteLine($"User has {amountOfBooksUserHolds} books.");
            }
        }
    }
}
