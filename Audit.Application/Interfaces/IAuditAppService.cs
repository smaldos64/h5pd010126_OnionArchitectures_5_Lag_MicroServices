using Audit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit.Application.Interfaces
{
    public interface IAuditAppService
    {
        void RegisterActivity(CreateAuditEntryDTO request);
    }
}
