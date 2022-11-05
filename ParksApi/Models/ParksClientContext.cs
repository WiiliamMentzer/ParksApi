using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ParksClient.Models
{
  public class ParksClientContext : DbContext
  {
    public ParksClientContext(DbContextOptions<ParksClientContext> options) : base (options) { }

    public DbSet<State> States { get; set; }
    public DbSet<Park> Parks { get; set; }

    public DbSet<StatePark> StatePark { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}