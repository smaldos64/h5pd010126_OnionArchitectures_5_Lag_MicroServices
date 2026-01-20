using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit.Application.DTOs
{
    public record CreateAuditLogRequestDTO
    (
        int AccountId,
        float Amount,
        string Action,
        DateTime Timestamp
    );
}
