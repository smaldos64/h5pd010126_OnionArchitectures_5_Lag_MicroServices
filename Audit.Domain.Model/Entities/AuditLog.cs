using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit.Domain.Model.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public float Amount { get; set; }
        public string ?Action { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
