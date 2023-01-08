using System.Collections.Generic;

namespace EFConsole.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int Quantity { get; set; }

        // Внешний ключ
        public int AuthorId { get; set; }

        // Навигационные свойства
        public Author Author { get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<User> Users { get; set; } = new List<User>();

        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
