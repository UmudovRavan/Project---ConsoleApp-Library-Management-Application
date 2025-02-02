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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project___ConsoleApp__Library_Management_Application_.Service.Implementation
{
    public class LoanService : ILoanService
    {
        public void Create(Loan loan)
        {

            if (loan is null) throw new ArgumentNullException("Loan is null");
            if (loan.Id < 1) throw new NotValidException("Id is less than 1");
            if (loan.Borrower is null) throw new ArgumentNullException("Loan is null");

            ILoanRepository loanRepository = new LoanRepository();


            loan.CreateTime = DateTime.UtcNow.AddHours(4);
            loan.UpdateAt = DateTime.UtcNow.AddHours(4);

            loanRepository.Add(loan);
            loanRepository.Commit();
        }

        public void Delete(int id)
        {

            ILoanRepository loanRepository = new LoanRepository();
            var data = loanRepository.GetById(id);

            if (data is null) throw new NullReferenceException();
            if (id < 1) throw new NotValidException("Id is less than 1");

            data.IsDeleted = true;
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            loanRepository.Commit();
        }

        public List<Loan> GetAll()
        {
            ILoanRepository loanRepository = new LoanRepository();

            if (loanRepository.GetAll() is null) throw new NullReferenceException();
            return loanRepository.GetAll();
        }

        public Loan GetById(int id)
        {
            ILoanRepository loanRepository = new LoanRepository();



            if (loanRepository.GetById(id) is null) throw new NotValidException();
            if (id < 1) throw new NotValidException("Id is less than 1");

            return loanRepository.GetById(id);
        }

        public void Update(int id, Loan loan)
        {
            ILoanRepository loanRepository = new LoanRepository();


            var loanUpdate = loanRepository.GetById(id);

            if (loanUpdate is null) throw new NullReferenceException();
            if (id < 1) throw new NotValidException("Idis less than 1");
            if (loan is null) throw new NullReferenceException();
            if (loan.Id < 1) throw new NotValidException();

            loanUpdate.LoanItems = loan.LoanItems;
            loanUpdate.Borrower = loan.Borrower;
            loanUpdate.LoanTime = loan.LoanTime;
            loanUpdate.ReturnDate = loan.ReturnDate;
            loanUpdate.MustReturnDate = loan.MustReturnDate;
            loanUpdate.BorrowerId = loan.BorrowerId;
            loanUpdate.CreateTime = loan.CreateTime;
            loanUpdate.UpdateAt = loan.UpdateAt;
            loanUpdate.IsDeleted = loan.IsDeleted;


            loanRepository.Commit();

        }
    }
}
