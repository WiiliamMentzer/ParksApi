using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ParksClient.Models
{
    public class State
    {
      public State()
      {
        this.Parks = new HashSet<Park>();
      }

      public int StateId { get; set; }
      [Required]
      [StringLength(25, ErrorMessage = "State Title must be between 0 and 25 characters")]
      public string StateTitle { get; set; }
      public int StatePopulation { get; set; }

      [JsonIgnore]      
      public virtual ICollection<Park> Parks { get; set; }
    }
}