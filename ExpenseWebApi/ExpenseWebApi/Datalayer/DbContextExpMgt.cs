using ExpenseWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseWebApi.Datalayer
{
    public class DbContextExpMgt : DbContext
    {
        public DbContextExpMgt(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExpenseEntity> Expenses { get; set; }
    }
}
