﻿using Project___ConsoleApp__Library_Management_Application_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Repository.Interface;

public interface ILoanItemRepository : IGenericRepository<LoanItem>
{
    List<LoanItem> GetAllByInclude();
    LoanItem GetByIdInclude(int id);
}
