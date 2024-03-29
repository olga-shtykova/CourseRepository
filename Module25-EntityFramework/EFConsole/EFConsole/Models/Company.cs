﻿using System.Collections.Generic;

namespace EFConsole.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? City { get; set; } 

        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();
    }
}
