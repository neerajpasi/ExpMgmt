
using Microsoft.EntityFrameworkCore;
using ExpenseManagement.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExpenseManagement.DataLayer
{
    public class DbContextExpMgt : DbContext
    {
        public DbContextExpMgt(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ExpenseEntity> Expenses { get; set; }
    }
}
