using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Model.Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        public float Balance { get; private set; }
        public string ?Owner { get; set; }

        public void Deposit(float amount) => Balance += amount;

        public void Withdraw(float amount)
        {
            if (amount > Balance) throw new InvalidOperationException("Ikke nok penge.");
            Balance -= amount;
        }
    }
}
