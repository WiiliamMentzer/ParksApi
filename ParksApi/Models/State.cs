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
      [StringLength(25, ErrorMessage = "Group Title must be between 0 and 25 characters")]
      public string GroupTitle { get; set; }
      public int GroupPopulation { get; set; }
      public DateTime GroupCreated { get; set; }
      
      public virtual ICollection<GroupMember> JoinParks { get; set; }
    }
}