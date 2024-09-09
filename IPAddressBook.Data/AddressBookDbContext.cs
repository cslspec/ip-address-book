using IPAddressBook.Model;
using Microsoft.EntityFrameworkCore;

namespace IPAddressBook.Data
{
    /// <summary>
    /// Database context for IP addresses.
    /// </summary>
    public class AddressBookDbContext : DbContext
    {
        /// <summary>
        /// Use SQLite.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=ip.db");

        /// <summary>
        /// Use Table-per-type configuration since SQLite does not support
        /// Use Table-per-concrete-type configuration.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<IPAddressBase>().UseTptMappingStrategy();

        public DbSet<IPv4Address> IPv4Addresses { get; set; }

        public DbSet<IPv6Address> IPv6Addresses { get; set; }
    }
}
