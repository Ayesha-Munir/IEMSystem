using IEM.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IEM.Data
{
    public class IEM_DbContext : DbContext
    {
        public IEM_DbContext(DbContextOptions<IEM_DbContext> options) : base(options) { }

        // TABLES
        // User
        public DbSet<User> Users { get; set; }

        //Income
        public DbSet<Income> Incomes { get; set; }
        //Expenditure
        public DbSet<Expenditure> Expenditures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ForeignKey
            modelBuilder.Entity<User>()
                .HasMany(i => i.Incomes)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expenditures)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserID);

        }
    }
}

