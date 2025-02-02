using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.MyException.Common;
using Project___ConsoleApp__Library_Management_Application_.Repository.Implementation;
using Project___ConsoleApp__Library_Management_Application_.Repository.Interface;
using Project___ConsoleApp__Library_Management_Application_.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Service.Implementation
{
    public class BookService : IBookService
    {
        public void Create(Book book)
        {
            if (book is null) throw new ArgumentNullException("Book is null");
            if(string.IsNullOrWhiteSpace(book.Title)) throw new ArgumentNullException("Title is null");
            if (string.IsNullOrWhiteSpace(book.Description)) throw new ArgumentNullException("Description is null");
            if(book.PublishedYear <= 0) throw new NotValidException("Published year is less than 0");

            IBookRepository bookRepository = new BookRepository();


            book.CreateTime = DateTime.UtcNow.AddHours(4);
            book.UpdateAt = DateTime.UtcNow.AddHours(4);

            bookRepository.Add(book);
            bookRepository.Commit();
        }

        public void Delete(int id)
        {
            IBookRepository bookRepository = new BookRepository();
            var data = bookRepository.GetById(id);
            if (data is null) throw new NotFoundException("Book is not found");
            if (id < 1) throw new NotValidException("Id is less than 1");

            data.IsDeleted = true;
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            bookRepository.Commit();
        }

        public List<Book> GetAll()
        {
            IBookRepository bookRepository = new BookRepository();
            if(bookRepository.GetAll() is null) throw new NotFoundException("Book is not found");
            return bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            IBookRepository bookRepository= new BookRepository();
            if (bookRepository.GetById(id) is null) throw new NotFoundException("Not found");
            if (id < 1) throw new NotValidException("Id is less than 1");
            return bookRepository.GetById(id);
        }

        public void Update(int id, Book book)
        {
            IBookRepository bookRepository = new BookRepository();
            var bookUpdate = bookRepository.GetById(id);
            if (bookUpdate is null) throw new NotFoundException("Not found");
            if (id <= 1) throw new NotValidException("Not valid");
            if (book is null) throw new NullReferenceException("Book is null");
            if(string.IsNullOrWhiteSpace(book.Title)) throw new NullReferenceException("Title is null");
            if (string.IsNullOrEmpty(book.Description)) throw new NullReferenceException("Description is null");
            if (book.PublishedYear <= 0) throw new NotValidException("Published year less than 0");

            bookUpdate.Title = book.Title;
            bookUpdate.Description = book.Description;
            bookUpdate.PublishedYear = book.PublishedYear;
            bookUpdate.Authors = book.Authors;
            bookUpdate.CreateTime = book.CreateTime;
            bookUpdate.UpdateAt = book.UpdateAt;
            bookUpdate.IsDeleted = book.IsDeleted;  

            bookRepository.Commit();     
        }
    }
}
