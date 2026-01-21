using Account.Infrastructure.Persistence;
using Account.Domain.Services.Interfaces;
using Account.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankDbContext _db;
        public AccountRepository(BankDbContext db) => _db = db;

        public BankAccount GetById(int id) => _db.Accounts.Find(id) ?? throw new Exception("Konto ikke fundet");
        public IEnumerable<BankAccount> GetAll() => _db.Accounts.ToList();
        public void Add(BankAccount acc) { _db.Accounts.Add(acc); _db.SaveChanges(); }
        public void Update(BankAccount acc) { _db.Update(acc); _db.SaveChanges(); }
        public void Delete(int id)
        {
            var acc = GetById(id);
            _db.Accounts.Remove(acc);
            _db.SaveChanges();
        }
    }
}
