﻿namespace Contactly.Models
{
    public class AddContactRequestDTO
    {
        public required string ContactName { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public bool Favorite { get; set; }
    }
}
