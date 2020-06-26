using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Entities;

namespace PhoneBook.Infrastructure.DataContext
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {
        }

        DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
