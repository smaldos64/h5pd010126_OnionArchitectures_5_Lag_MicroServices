using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Account.Domain.Model.Entities;

namespace Account.Domain.Services.Interfaces
{
    public interface IAccountRepository
    {
        BankAccount GetById(int id);
        IEnumerable<BankAccount> GetAll();
        void Add(BankAccount account);
        void Update(BankAccount account);
        void Delete(int id);
    }
}
