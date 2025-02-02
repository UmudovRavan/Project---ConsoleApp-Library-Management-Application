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

public class LoanRepository : GenericRepository<Loan>, ILoanRepository
{
    private readonly AppDbContext _appDbContext;
    public LoanRepository()
    {
        _appDbContext = new AppDbContext();
    }

    public List<Loan> GetAllByInclude()
    {
        return _appDbContext.Loans
            .Include(x => x.Borrower)
            .ToList();
    }

    public Loan? GetByIdInclude(int id)
    {
        var loanInclude = _appDbContext.Loans
            .Include(x => x.Borrower)
            .FirstOrDefault(x => x.Id == id);
        return loanInclude;
    }
}
