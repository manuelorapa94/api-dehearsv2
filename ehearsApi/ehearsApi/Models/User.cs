using System.ComponentModel.DataAnnotations;

namespace ehearsApi.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public string? Username { get; set; } 
        public string? Password { get; set; }

    }
}
