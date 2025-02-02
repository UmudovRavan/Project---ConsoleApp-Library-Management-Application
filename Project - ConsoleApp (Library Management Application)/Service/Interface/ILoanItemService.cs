using Project___ConsoleApp__Library_Management_Application_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Service.Interface
{
    public interface ILoanItemService
    {
        void Create(LoanItem loanItem);
        void Update(int id, LoanItem loanItem);
        void Delete(int id);
        List<LoanItem> GetAll();
        LoanItem GetById(int id);
    }
}
