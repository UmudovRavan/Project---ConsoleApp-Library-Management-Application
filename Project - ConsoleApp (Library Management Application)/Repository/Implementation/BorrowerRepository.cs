﻿using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Repository.Implementation;

public class BorrowerRepository : GenericRepository<Borrower>,IBorrowerRepository
{
}
