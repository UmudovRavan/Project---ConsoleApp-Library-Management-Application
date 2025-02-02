using Project___ConsoleApp__Library_Management_Application_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Service.Interface
{
    public interface IBorrowerService
    {
        void Create (Borrower borrower);
        void Update (int id,Borrower borrower);
        void Delete (int id);
        List<Borrower> GetAll ();
        Borrower GetById (int id);
    }
}
