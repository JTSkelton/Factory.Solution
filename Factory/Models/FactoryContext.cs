using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machiens { get; set; }
    public DbSet<EngineerMachiens> EngineerMachiens { get; set; }

    public FactoryContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}