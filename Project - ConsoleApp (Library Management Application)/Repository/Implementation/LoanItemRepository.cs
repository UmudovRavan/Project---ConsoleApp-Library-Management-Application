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

public class LoanItemRepository : GenericRepository<LoanItem>, ILoanItemRepository
{
    private readonly AppDbContext _appDbContext;
    public LoanItemRepository()
    {
        _appDbContext = new AppDbContext();
    }
    public List<LoanItem> GetAllByInclude()
    {
        return _appDbContext.LoanItems.
            Include(x => x.Loan).
            Include(x => x.Book).
            ToList();
    }

    public LoanItem GetByIdInclude(int id)
    {
        var loanItemInclude = _appDbContext.LoanItems
            .Include(x => x.Loan)
            .Include(x => x.Book)
            .FirstOrDefault(x => x.Id == id);
        return loanItemInclude;
    }
}
