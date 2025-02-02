using Project___ConsoleApp__Library_Management_Application_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Service.Interface
{
    public interface IAuthorServices
    {
        void Create(Author author);
        void Update(int id,Author author);
        void Delete(int id);
        Author GetById(int id);
        List<Author> GetAll();
    }
}
