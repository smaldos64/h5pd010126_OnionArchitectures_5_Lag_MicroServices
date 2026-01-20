using Audit.Application.Interfaces;
using Audit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Domain.Model.Entities;

namespace Audit.Application.Services
{
    public class AuditAppService : IAuditAppService
    {
        private readonly IAuditAppService _repo;
        public AuditAppService(IAuditAppService repo) => _repo = repo;
        public void RegisterActivity(CreateAuditLogRequestDTO request)
        {
            // Implementation for registering an audit activity
            var auditActivity = new AuditLog { AccountId = request.AccountId,
                                               Action = request.Action,
                                               Amount = request.Amount,
                                               Timestamp = DateTime.Now };
            
            _repo.Add(auditActivity);
        }

        public IEnumerable<AuditLogDTO> GetLogsByAccount(int accountId)
        {
            var logs = _repo.GetByAccountId(accountId);
            return logs.Adapt<IEnumerable<AuditLogDTO>>();
        }
    }
}
