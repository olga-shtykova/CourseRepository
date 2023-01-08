using System.Collections.Generic;

namespace EFConsole.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        // Внешний ключ
        public int CompanyId { get; set; }

        // Навигационные свойства
        public Company Company { get; set; }

        public UserCredential UserCredential { get; set; }

        public List<Topic> Topics { get; set; } = new List<Topic>();

        public List<Book> Books { get; set; } = new List<Book>();

        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
