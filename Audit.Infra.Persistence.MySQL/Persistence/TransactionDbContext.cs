using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Audit.Domain.Model.Entities;

namespace Audit.Infrastructure.Persistence
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> opt) : base(opt) { }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
