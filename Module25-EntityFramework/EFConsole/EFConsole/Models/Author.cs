using System.Collections.Generic;

namespace EFConsole.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
