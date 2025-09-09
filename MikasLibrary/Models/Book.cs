using System.ComponentModel.DataAnnotations;

namespace MikasLibrary.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public Guid? BorrowedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BorrowDate { get; set; }

        public User? BorrowedByUser { get; set; }

        public Book(string title, string author)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
        }
    }
}
