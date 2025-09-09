using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MikasLibrary.Models
{
    [Index(nameof(NationalId), IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string NationalId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Book>? BorrowedBooks { get; set; }

        public User(string nationalId, string name, string email)
        {
            Id = Guid.NewGuid();
            NationalId = nationalId;
            Name = name;
            Email = email;
        }
    }
}
