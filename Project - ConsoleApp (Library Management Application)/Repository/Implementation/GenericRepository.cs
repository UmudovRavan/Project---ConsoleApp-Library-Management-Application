using Project___ConsoleApp__Library_Management_Application_.Data;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _dbContext;
        public GenericRepository()
        {
            _dbContext = new AppDbContext();
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var data = _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
            return data;
        }

    }
}
