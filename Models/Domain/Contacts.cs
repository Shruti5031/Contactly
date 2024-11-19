using System.ComponentModel.DataAnnotations;

namespace Contactly.Models.Domain
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }
        public required string ContactName { get; set; }
        public string? Email { get; set; }
        public required string Phone{ get; set; }
        public bool Favorite { get; set; }
    }
}
