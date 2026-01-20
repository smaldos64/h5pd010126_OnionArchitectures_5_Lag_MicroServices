using Audit.Application.DTOs;
using Audit.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Audit.InternalWebApi.Controllers
{
    [ApiController]
    [Route("api/internal/[controller]")] // Giver URL: api/internal/auditinternal
    public class AuditInternalController : ControllerBase
    {
        private readonly IAuditAppService _auditAppService;

        public AuditInternalController(IAuditAppService auditAppService)
        {
            _auditAppService = auditAppService;
        }

        // POST: api/internal/auditinternal
        [HttpPost]
        public IActionResult CreateAuditEntry([FromBody] CreateAuditLogRequestDTO request)
        {
            if (request == null) return BadRequest();

            // Vi sender anmodningen videre til Application Layer
            _auditAppService.RegisterActivity(request);

            // Vi returnerer 201 Created eller 200 Ok
            return Ok(new { message = "Audit log modtaget og gemt i MySQL." });
        }

        // GET: api/internal/auditinternal/123
        [HttpGet("{accountId}")]
        public IActionResult GetLogsForAccount(int accountId)
        {
            var logs = _auditAppService.GetLogsByAccount(accountId);
            return Ok(logs);
        }
    }
}
