using EFConsole.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFConsole.DAL
{
    public class BookRepository
    {
        private readonly AppContext _db = new AppContext();

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _db.Books.FirstOrDefault(u => u.Id == id);
        }

        public void AddBook(Book book)
        {
            _db.Books.Add(new Book { Title = book.Title, Year = book.Year, });
            _db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = new Book { Id = id };

            _db.Entry(book).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public void UpdateBookYear(int id, int newYear)
        {
            var book = _db.Books.FirstOrDefault(u => u.Id == id);
            book.Year = newYear;

            _db.Entry(book).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // Получать список книг определенного жанра и вышедших между определенными годами.
        public List<Book> GetBooksByGenreAndBetweenYears(int genreId, int yearMin, int yearMax)
        {
            return _db.Books
                .Where(b => b.Genres.Any(x => x.Id == genreId) &&
                    b.Year >= yearMin && b.Year <= yearMax)
                .ToList();
        }

        // Получать количество книг определенного автора в библиотеке.
        public int GetBooksCountByAuthorId(int authorId)
        {
            return _db.Books.Count(b => b.AuthorId == authorId);
        }

        //Получать количество книг определенного жанра в библиотеке.
        public int GetBooksCountByGenreId(int genreId)
        {
            return _db.Books.Count(b => b.Genres.Any(x => x.Id == genreId));
        }

        //Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool DoesBookWithAuthorAndTitleExist(string authorName, string title)
        {
            return _db.Books.Any(b => b.Author.Name == authorName && b.Title == title);
        }

        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool DoesUserHaveABook(int bookId)
        {
            return _db.Books.Any(b => b.Subscriptions.Any(x => x.BookId == bookId));
        }

        //Получать количество книг на руках у пользователя.
        public int GetAmountOfBooksInHoldByUserId(int userId)
        {
            return _db.Books.Count(b => b.Subscriptions.Any(x => x.UserId == userId));
        }

        //Получение последней вышедшей книги.
        public Book GetAmountOfBooksInHoldByUserId()
        {
            var book = _db.Books.OrderByDescending(x => x.Year).FirstOrDefault();

            return book;
        }

        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> GetBooksSortedByTitleAscending()
        {
            return _db.Books.OrderBy(x => x.Title).ToList();
        }

        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> GetBooksSortedByTitleDescending()
        {
            return _db.Books.OrderByDescending(x => x.Title).ToList();
        }
    }
}
