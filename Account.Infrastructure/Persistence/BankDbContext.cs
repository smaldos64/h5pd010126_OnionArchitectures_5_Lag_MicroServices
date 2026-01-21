using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Persistence
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> opt) : base(opt) { }
        public DbSet<BankAccount> Accounts { get; set; }
    }
}
