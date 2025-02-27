﻿using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.MyException.Common;
using Project___ConsoleApp__Library_Management_Application_.Repository.Implementation;
using Project___ConsoleApp__Library_Management_Application_.Repository.Interface;
using Project___ConsoleApp__Library_Management_Application_.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Service.Implementation
{
    public class BorrowerService : IBorrowerService
    {
        public void Create(Borrower borrower)
        {
            if (borrower is null) throw new ArgumentNullException("Borrower is null");
            if (string.IsNullOrWhiteSpace(borrower.Name)) throw new ArgumentNullException("Borrower name is null");
            if (borrower.Email is null) throw new ArgumentNullException("Email is null");
            
            IBorrowerRepository borrowerRepository = new BorrowerRepository();


            borrower.CreateTime = DateTime.UtcNow.AddHours(4);
            borrower.UpdateAt = DateTime.UtcNow.AddHours(4);

            borrowerRepository.Add(borrower);
            borrowerRepository.Commit();
        }

        public void Delete(int id)
        {
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            var data = borrowerRepository.GetById(id);

            if (data is null) throw new NullReferenceException();
           

            data.IsDeleted = true;
            data.UpdateAt = DateTime.UtcNow.AddHours(4);
            borrowerRepository.Commit();
        }

        public List<Borrower> GetAll()
        {

            IBorrowerRepository borrowerRepository = new BorrowerRepository();

            if(borrowerRepository.GetAll() is null) throw new NullReferenceException();
            return borrowerRepository.GetAll();
        }

        public Borrower GetById(int id)
        {

            IBorrowerRepository borrowerRepository = new BorrowerRepository();

            if(borrowerRepository.GetById(id) is null) throw new NotValidException();
            if (id < 1) throw new NotValidException("Idis less than 1");

            return borrowerRepository.GetById(id);
        }

        public void Update(int id, Borrower borrower)
        {
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            var borrowerUpdate = borrowerRepository.GetById(id);

            if(borrowerUpdate is null) throw new NullReferenceException();
            
            if (borrower is null) throw new NullReferenceException();
            if (string.IsNullOrWhiteSpace(borrower.Name)) throw new NullReferenceException();

            borrowerUpdate.Name = borrower.Name;
            borrowerUpdate.UpdateAt = DateTime.UtcNow.AddHours(4);
            
            borrowerUpdate.Email = borrower.Email;
            
            borrowerRepository.Commit();
        }
    }
}
