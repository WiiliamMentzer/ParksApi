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
          new State { StateId = 1, StateTitle = "California", StatePopulation = 1},
          new State { StateId = 2, StateTitle = "Texas", StatePopulation = 2},
          new State { StateId = 3, StateTitle = "Washington", StatePopulation = 3},
          new State { StateId = 4, StateTitle = "Oregon", StatePopulation = 4},
          new State { StateId = 5, StateTitle = "Nevada", StatePopulation = 5}
        ); 

      builder.Entity<Park>()
      .HasData(
          new Park { ParkId = 1, ParkName = "Yosemite", ParkNational = true, StateId = 1},
          new Park { ParkId = 2, ParkName = "Joshua Tree", ParkNational = true, StateId = 1},
          new Park { ParkId = 3, ParkName = "Olympic National", ParkNational = true, StateId = 3},
          new Park { ParkId = 4, ParkName = "Cedar Lake", ParkNational = true, StateId = 4},
          new Park { ParkId = 5, ParkName = "Big Spring State", ParkNational = false, StateId = 2}
        );
        
      // builder.Entity<StatePark>().HasData
      //   (
      //     new StatePark
      //     {
      //       StateParkId = 1,
      //       StateId = 1,
      //       ParkId = 1
      //     },
      //     new StatePark
      //     {
      //       StateParkId = 2,
      //       StateId = 1,
      //       ParkId = 2
      //     },
      //     new StatePark
      //     {
      //       StateParkId = 3,
      //       StateId = 3,
      //       ParkId = 3
      //     },
      //     new StatePark
      //     {
      //       StateParkId = 4,
      //       StateId = 4,
      //       ParkId = 4
      //     }
      // ); 
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