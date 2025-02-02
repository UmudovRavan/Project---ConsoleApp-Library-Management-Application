using Project___ConsoleApp__Library_Management_Application_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Service.Interface
{
    public interface IBookService 
    {
        void Create(Book book);
        void Update(int id,Book book);
        Book GetById(int id);
        List<Book> GetAll();
        void Delete(int id);
    }
}
