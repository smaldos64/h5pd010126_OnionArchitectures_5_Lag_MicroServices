using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.DTO.ExternalRequests
{
    public record CreateAuditLogRequest
    (
        int AccountId,
        float Amount,
        string Action,
        DateTime Timestamp
    );
}
