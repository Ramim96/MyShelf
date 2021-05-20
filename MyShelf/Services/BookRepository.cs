using MyShelf.Data;
using MyShelf.Interfaces;
using MyShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShelf.Services
{
    public class BookRepository : IBook
    {
        // Database context service 
        private readonly ApplicationDbContext _dbContext;

        // Constructor
        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all books from the database
        public IEnumerable<Book> GetAllBooks
        {
            get
            {
                // set field member and return all books to client
                return _dbContext.Book;
            }
        }

        // Get a book by a unique id
        public Book GetBookById(int bookId)
        {
            return _dbContext.Book.FirstOrDefault(b => b.Id == bookId);
        }

        // Create and store a new book in the database
        public void CreateBook(Book bookToCreate)
        {
            // Insert data in the database
            _dbContext.Add(bookToCreate);
            // Update database
            _dbContext.SaveChanges();

            return;
        }

        // Edit and update a book in the database
        public void EditBook(Book bookToEdit)
        {
            // Edit/Update data in the database
            _dbContext.Book.Update(bookToEdit);
            // Update database
            _dbContext.SaveChanges();

            return;
        }

        // Delete a book from the database
        public void DeleteBook(Book bookToDelete)
        {
            // Remove data from the database
            _dbContext.Book.Remove(bookToDelete);
            //Update database
            _dbContext.SaveChanges();

            return;
        }
    }
}
