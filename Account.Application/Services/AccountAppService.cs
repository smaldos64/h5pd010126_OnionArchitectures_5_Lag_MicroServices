using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mapster;
using Account.Application.DTO;
using Account.Application.Interfaces;
using Account.Domain.Model.Entities;
using Account.Domain.Services.Interfaces;
using System.Runtime.CompilerServices;
using Account.Application.DTO.ExternalRequests;

namespace Account.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountRepository _repo;
        private readonly IAuditIntegrationService _auditService;

        public AccountAppService(IAccountRepository repo,
                                 IAuditIntegrationService auditService)
        {
            _repo = repo;
            _auditService = auditService;
        }

        public AccountResponseDTO GetAccount(int id) => _repo.GetById(id).Adapt<AccountResponseDTO>();

        public IEnumerable<AccountResponseDTO> GetAllAccounts() => _repo.GetAll().Adapt<IEnumerable<AccountResponseDTO>>();

        public void CreateAccount(CreateAccountRequest req)
        {
            var acc = new BankAccount { Owner = req.Owner };
            acc.Deposit(req.InitialBalance);
            _repo.Add(acc);
        }

        public async Task Deposit(TransactionRequest req)
        {
            var acc = _repo.GetById(req.AccountId);
            acc.Deposit(req.Amount);
            _repo.Update(acc);
            var transactionRequest = new CreateAuditLogRequest
            (
                AccountId: req.AccountId,
                Action: "Indsat",
                Amount: req.Amount,
                Timestamp: DateTime.Now
            );
            await _auditService.SendToAuditAsync(transactionRequest);
        }

        public async Task Withdraw(TransactionRequest req)
        {
            var acc = _repo.GetById(req.AccountId);
            acc.Withdraw(req.Amount);
            _repo.Update(acc);
            var transactionRequest = new CreateAuditLogRequest
            (
                AccountId: req.AccountId,
                Action: "Hævet",
                Amount: req.Amount,
                Timestamp: DateTime.Now
            );
            await _auditService.SendToAuditAsync(transactionRequest);
        }

        public void DeleteAccount(int id) => _repo.Delete(id);
    }
}
