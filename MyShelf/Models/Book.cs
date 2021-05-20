using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShelf.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Book title")]
        [Required(ErrorMessage = "Provide book title")]
        [RegularExpression(@"^[\w\W\d\s]+$", ErrorMessage = "Only letters or numbers")]
        [MinLength(1, ErrorMessage = "Must be at least more than one character")]
        public string Title { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Provide author")]
        [RegularExpression(@"^[\w\d\s\.]+$", ErrorMessage = "Only letters")]
        [MinLength(1, ErrorMessage = "Must be at least more than one character")]
        public string Author { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Provide Genre")]
        [RegularExpression(@"^[\w\W\d\s]+$", ErrorMessage = "Only letters")]
        [MinLength(1, ErrorMessage = "Must be at least more than one character")]
        public string Genre { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Provide Price")]
        [RegularExpression(@"^[\W\d\s]+$", ErrorMessage = "Provide the price in a string format")]
        public string Price { get; set; }

        [Display(Name = "Book cover")]
        public string CoverImg { get; set; }

        [Display(Name = "Book synopsis")]
        [Required(ErrorMessage = "Provide book synopsis")]
        [MinLength(1, ErrorMessage = "Must be at least more than one character")]
        public string Synopsis { get; set; }
    }
}
