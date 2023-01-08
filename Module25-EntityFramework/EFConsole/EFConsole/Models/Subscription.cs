using System;
namespace EFConsole.Models
{
    public class Subscription
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public DateTime StartDate { get; set; } // дата выдачи

        public DateTime? FinishDate { get; set; } // дата возврата
    }
}
