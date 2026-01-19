using Account.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Services.Services
{
    public class TransferDomainService
    {
        //public void ValidateTransfer(Account from, decimal amount)
        //{
        //    if (from.Balance < amount) throw new InvalidOperationException("Ingen dækning");
        //}

        public void Transfer(BankAccount from, BankAccount to, float amount)
        {
            from.Withdraw(amount);
            to.Deposit(amount);
        }
    }
}
