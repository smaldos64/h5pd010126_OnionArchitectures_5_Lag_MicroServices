using Audit.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit.Domain.Services.Interfaces
{
    public interface IAuditRepository
    {
        void Add(AuditLog log);
        AuditLog GetByAccountId(int accountId);
    }
}
