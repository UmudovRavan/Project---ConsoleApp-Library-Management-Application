using Project___ConsoleApp__Library_Management_Application_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Service.Interface
{
    public interface ILoanService
    {
        void Create(Loan loan);
        void Update(int id,Loan loan);
        void Delete(int id);    
        List<Loan> GetAll();
        Loan GetById(int id);
    }
}
