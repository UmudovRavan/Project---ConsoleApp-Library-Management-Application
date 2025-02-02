using Project___ConsoleApp__Library_Management_Application_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        void Add(T entity);
        T GetById (int id);
        List<T> GetAll(); 
        void Delete(T entity);
        int Commit();
    }
}
