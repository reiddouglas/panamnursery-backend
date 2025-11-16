using Microsoft.EntityFrameworkCore;
using PanAmNursery.Entities;

namespace PanAmNursery.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}

