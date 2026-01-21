using Audit.Infrastructure.Persistence;
using Audit.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Domain.Services.Interfaces;

namespace Audit.Infrastructure.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly TransactionDbContext _db;
        public AuditRepository(TransactionDbContext db) => _db = db;

        public IEnumerable<AuditLog> GetAll() => _db.AuditLogs.ToList();
        
        public void Add(AuditLog log)
        {
            _db.AuditLogs.Add(log);
            _db.SaveChanges();
        }
        public IEnumerable<AuditLog> GetByAccountId(int accountId)
        {
            return _db.AuditLogs.Where(log => log.AccountId == accountId).ToList();
        }

    }
}
