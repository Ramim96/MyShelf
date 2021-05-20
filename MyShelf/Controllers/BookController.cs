using Microsoft.AspNetCore.Mvc;
using MyShelf.Interfaces;
using MyShelf.Models;
using MyShelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShelf.Controllers
{
    public class BookController : Controller
    {
        // Database context service 
        private readonly IBook _bookRepository;

        // Constructor
        public BookController(IBook bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET /Book/BooksList
        // Get the page with the list of books
        public IActionResult BooksList()
        {
            // Get all books from the database and put it in the view model
            BooksListViewModel booksListViewModel = new BooksListViewModel();
            booksListViewModel.AllBooks = _bookRepository.GetAllBooks;

            // Return view with data
            return View(booksListViewModel);
        }

        // GET /Book/CreateBook
        // Get the create book page
        public IActionResult CreateBook()
        {
            // Return view
            return View();
        }

        // POST /Book/CreateBook
        // Post a new book in the database
        [HttpPost]
        public IActionResult CreateBook(Book bookToCreate)
        {
            // Assert model state validation
            if(ModelState.IsValid)
            {
                // Create and store a new book in the database
                _bookRepository.CreateBook(bookToCreate);

                // Redirect to action
                return RedirectToAction("BooksList");
            }
            else
            {
                // Return view with data
                return View(bookToCreate);
            }
        }

        // GET /Book/EditBook
        // Get the edit/update book page
        public IActionResult EditBook(int? bookId)
        {
            // Assert book id
            if (bookId == null || bookId == 0)
            {
                // Return not found page
                return NotFound();
            }
            else
            {
                // Create and store a new book in the database
                Book book = _bookRepository.GetBookById((int)bookId);

                // Assert book
                if (book == null)
                {
                    // Return not found page
                    return NotFound();
                }
                else
                {
                    return View(book);
                }
            }
        }

        // POST /Book/EditBook
        // Post an edited/updated book in the database
        [HttpPost]
        public IActionResult EditBook(Book bookToEdit)
        {
            // Assert model state
            if(ModelState.IsValid)
            {
                // Edit and update a book in the database
                _bookRepository.EditBook(bookToEdit);

                // Redirect to action
                return RedirectToAction("BooksList");
            }
            else
            {
                return View(bookToEdit);
            }
        }

        // GET /Book/DeleteBook
        // Get the delete book page
        public IActionResult DeleteBook(int? bookId)
        {
            // Assert book id
            if (bookId == null || bookId == 0)
            {
                // Return not found page
                return NotFound();
            }
            else
            {
                // Create and store a new book in the database
                Book book = _bookRepository.GetBookById((int)bookId);

                // Assert book
                if (book == null)
                {
                    // Return not found page
                    return NotFound();
                }
                else
                {
                    return View(book);
                }
            }
        }

        // POST /Book/DeleteBook
        // Delete book in the database
        [HttpPost]
        public IActionResult Post_DeleteBook(int? bookId)
        {
            // Assert book id
            if (bookId == null || bookId == 0)
            {
                // Return not found page
                return NotFound();
            }
            else
            {
                // Create and store a new book in the database
                Book book = _bookRepository.GetBookById((int)bookId);

                // Assert book
                if (book == null)
                {
                    // Return not found page
                    return NotFound();
                }
                else
                {
                    // Delete a book from the database
                    _bookRepository.DeleteBook(book);

                    // Redirect to action
                    return RedirectToAction("BooksList");
                }
            }
        }

        // GET /Book/BookSynopsis
        // Get the edit/update book page
        public IActionResult BookDetails(int? bookId)
        {
            // Assert book id
            if (bookId == null || bookId == 0)
            {
                // Return not found page
                return NotFound();
            }
            else
            {
                // Create and store a new book in the database
                Book book = _bookRepository.GetBookById((int)bookId);

                // Assert book
                if (book == null)
                {
                    // Return not found page
                    return NotFound();
                }
                else
                {
                    return View(book);
                }
            }
        }
    }
}
