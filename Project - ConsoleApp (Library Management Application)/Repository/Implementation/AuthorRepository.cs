using Microsoft.EntityFrameworkCore;
using Project___ConsoleApp__Library_Management_Application_.Data;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Repository.Implementation;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    private readonly AppDbContext _appDbContext;
    public AuthorRepository()
    {
        _appDbContext = new AppDbContext();
    }
    public List<Author> GetAllByInclude()
    {
        return _appDbContext.Authors
            .Include(x => x.Books)
            .ToList();
    }

    public Author? GetByIdInclude(int id)
    {
        var authorInclude = _appDbContext.Authors
            .Include(x => x.Books)
            .FirstOrDefault(x => x.Id == id);
        return authorInclude;
    }
}
