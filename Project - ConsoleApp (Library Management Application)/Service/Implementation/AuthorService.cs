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
    public class AuthorService : IAuthorServices
    {
        public void Create(Author author)
        {
            if (author is null) throw new ArgumentNullException("Author is null");
            if (string.IsNullOrWhiteSpace(author.Name)) throw new ArgumentNullException("Author name is null");
            
            IAuthorRepository authorRepository = new AuthorRepository();

            author.CreateTime = DateTime.UtcNow.AddHours(4);
            author.UpdateAt = DateTime.UtcNow.AddHours(4);

            authorRepository.Add(author);
            authorRepository.Commit();
        }

        public void Delete(int id)
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            var data = authorRepository.GetById(id);
            if (data is null) throw new NotFoundException("Not found");
            if (id < 1) throw new NotValidException("Id is less than 1");

            data.IsDeleted = true;
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            authorRepository.Commit();

        }

        public List<Author> GetAll()
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            if (authorRepository.GetAll() is null) throw new NotFoundException("Author not found");
            return authorRepository.GetAll();
        }

        public Author GetById(int id)
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            if (authorRepository.GetById(id) is null) throw new NotFoundException("Not found");
            if(id < 1) throw new NotValidException("Id is less than 1");
            return authorRepository.GetById(id);

        }

        public void Update(int id, Author author)
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            var authorUpdate = authorRepository.GetById(id);

            if (authorUpdate is null) throw new NotFoundException("Not found");
            if (id < 1) throw new NotValidException("Id is less than 1");
            if (author is null) throw new NullReferenceException("Author is null");
            if (string.IsNullOrWhiteSpace(author.Name)) throw new NullReferenceException("Name is null");
            

            authorUpdate.Name = author.Name;    
            authorUpdate.UpdateAt = author.UpdateAt;
            authorUpdate.CreateTime = author.CreateTime;
            authorUpdate.IsDeleted = author.IsDeleted;
            authorUpdate.Books = author.Books;  
            authorRepository.Commit();
        }
    }
}
