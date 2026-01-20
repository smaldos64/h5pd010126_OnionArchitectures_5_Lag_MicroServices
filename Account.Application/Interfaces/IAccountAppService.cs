using Account.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interfaces
{
    public interface IAccountAppService
    {
        AccountResponseDTO GetAccount(int id);
        IEnumerable<AccountResponseDTO> GetAllAccounts();
        void CreateAccount(CreateAccountRequest request);
        Task Deposit(TransactionRequest request);
        Task Withdraw(TransactionRequest request);
        void DeleteAccount(int id);
    }
}
