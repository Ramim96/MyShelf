using MyShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShelf.Interfaces
{
    public interface IBook
    {
        public IEnumerable<Book> GetAllBooks { get; }
        public Book GetBookById(int bookId);
        public void CreateBook(Book bookToCreate);
        public void EditBook(Book bookToEdit);
        public void DeleteBook(Book bookToDelete);
    }
}
