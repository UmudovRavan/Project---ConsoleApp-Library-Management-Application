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
    public class LoanItemServices : ILoanItemService
    {
        public void Create(LoanItem loanItem)
        {
            if (loanItem is null) throw new ArgumentNullException("LoanItem is null");
           
            if (loanItem.Loan is null) throw new ArgumentNullException("Loan is null");

            ILoanItemRepository loanItemRepository = new LoanItemRepository();


            loanItem.CreateTime = DateTime.UtcNow.AddHours(4);
            loanItem.UpdateAt = DateTime.UtcNow.AddHours(4);

            loanItemRepository.Add(loanItem);
            loanItemRepository.Commit();
        }

        public void Delete(int id)
        {
            ILoanItemRepository loanItemRepository = new LoanItemRepository();
            var data = loanItemRepository.GetById(id);

            if (data is null) throw new NullReferenceException();
           

            data.IsDeleted = true;
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            loanItemRepository.Commit();
        }

        public List<LoanItem> GetAll()
        {
            ILoanItemRepository loanItemRepository = new LoanItemRepository();

            if (loanItemRepository.GetAll() is null) throw new NullReferenceException();
            return loanItemRepository.GetAll();
        }

        public LoanItem GetById(int id)
        {
            ILoanItemRepository loanItemRepository = new LoanItemRepository();

            if (loanItemRepository.GetById(id) is null) throw new NotValidException();
           

            return loanItemRepository.GetById(id);

        }

        public void Update(int id, LoanItem loanItem)
        {
            ILoanItemRepository loanItemRepository = new LoanItemRepository();
            var loanItemUpdate = loanItemRepository.GetById(id);

            if (loanItemUpdate is null) throw new NullReferenceException();

            if (loanItem is null) throw new NullReferenceException();
            if (loanItem.Id < 1) throw new NotValidException();


            loanItemUpdate.Loan = loanItem.Loan;
            loanItemUpdate.Book = loanItem.Book;
            loanItemUpdate.UpdateAt = loanItem.UpdateAt;
            loanItemUpdate.CreateTime = loanItem.CreateTime;
            loanItemUpdate.BookId = loanItem.BookId;
            loanItemUpdate.IsDeleted = loanItem.IsDeleted;

            loanItemRepository.Commit();
        }
    }
}
