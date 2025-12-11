using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class ReaderModel
    {
        [Key]
        public int ReaderId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please enter Reader Name")]
        public string? ReaderName { get; set; }
        [Required(ErrorMessage = "Please enter Reader Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a Email Address")]
        public string? ReaderEmail { get; set; }
        [Required(ErrorMessage = "Please enter Reader Phone Number")]
        [Phone(ErrorMessage = "Please enter a Valid Phone Number")]
        public string? Phone { get; set; }
        [BindNever]
        [DataType(DataType.DateTime)]
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        [DataType(DataType.DateTime)]
        public DateTime? ReturnDate { get; set; }
        [BindNever]
        public BookModel Book { get; set; }
    }
}

