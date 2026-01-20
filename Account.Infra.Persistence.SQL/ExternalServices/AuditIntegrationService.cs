using Account.Application.DTO.ExternalRequests;
using Account.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.ExternalServices
{
    public class AuditIntegrationService : IAuditIntegrationService
    {
        public async Task SendToAuditAsync(CreateAuditLogRequest logData)
        {
            var client = _httpClientFactory.CreateClient();

            // URL'en peger på AuditInternalController i den anden service
            var url = "https://localhost:7001/api/internal/auditinternal";

            await client.PostAsJsonAsync(url, logData);
        }
    }
}
