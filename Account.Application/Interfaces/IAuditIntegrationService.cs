using Account.Application.DTO.ExternalRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Interfaces
{
    public interface IAuditIntegrationService
    {
        Task SendToAuditAsync(CreateAuditLogRequest logData);
    }
}
