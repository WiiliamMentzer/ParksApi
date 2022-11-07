using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ParksClient.Models
{
    public class State
    {
      public State()
      {
        this.JoinParks = new HashSet<StatePark>();
        this.StateCreated = DateTime.Now;
      }

      public int StateId { get; set; }
      [Required]
      [StringLength(25, ErrorMessage = "State Title must be between 0 and 25 characters")]
      public string StateTitle { get; set; }
      public int StatePopulation { get; set; }
      public DateTime StateCreated { get; set; }
      
      public virtual ICollection<StatePark> JoinParks { get; set; }
    }
}