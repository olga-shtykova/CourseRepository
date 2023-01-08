﻿using System.Collections.Generic;

namespace EFConsole.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
