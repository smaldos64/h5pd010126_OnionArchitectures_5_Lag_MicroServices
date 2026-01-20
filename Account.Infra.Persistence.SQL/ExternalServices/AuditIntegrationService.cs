using Account.Application.DTO.ExternalRequests;
using Account.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Account.Infrastructure.ExternalServices
{
    public class AuditIntegrationService : IAuditIntegrationService
    {
        private readonly HttpClient ?_httpClient;
        public AuditIntegrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task SendToAuditAsync(CreateAuditLogRequest logData)
        {
            if (_httpClient == null)
                throw new InvalidOperationException("HttpClient is not initialized.");
            // URL'en peger på AuditInternalController i den anden service
            var url = "api/internal/auditinternal";
            await _httpClient.PostAsJsonAsync(url, logData);
        }

        //public async Task SendToAuditAsync(CreateAuditLogRequest logData)
        //{
        //    var client = _httpClientFactory.CreateClient();

        //    // URL'en peger på AuditInternalController i den anden service
        //    var url = "https://localhost:7001/api/internal/auditinternal";

        //    await client.PostAsJsonAsync(url, logData);
        //}
    }
}
