using System;
using Microsoft.EntityFrameworkCore;

namespace PanAmNursery.Models;
public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options)
    {

    }
}
