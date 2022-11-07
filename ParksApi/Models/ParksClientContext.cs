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

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<State>()
      .HasData(
          new State { StateId = 1, StateTitle = "Matilda", StatePopulation = 1},
          new State { StateId = 2, StateTitle = "Rexie", StatePopulation = 2},
          new State { StateId = 3, StateTitle = "Matilda", StatePopulation = 3},
          new State { StateId = 4, StateTitle = "Pip", StatePopulation = 4},
          new State { StateId = 5, StateTitle = "Bartholomew", StatePopulation = 5}
        ); 

      builder.Entity<Park>()
      .HasData(
          new Park { ParkId = 1, ParkName = "Matilda"},
          new Park { ParkId = 2, ParkName = "Rexie"},
          new Park { ParkId = 3, ParkName = "Matilda"},
          new Park { ParkId = 4, ParkName = "Pip"},
          new Park { ParkId = 5, ParkName = "Bartholomew"}
        ); 
    }

    public DbSet<State> States { get; set; }
    public DbSet<Park> Parks { get; set; }

    // public DbSet<StatePark> StatePark { get; set; }


    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //   optionsBuilder.UseLazyLoadingProxies();
    // }
  }
}