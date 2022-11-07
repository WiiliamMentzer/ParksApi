using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ParksClient.Models
{
    public class Park
    {
        public Park()
        {
          // this.JoinStates = new HashSet<StatePark>();
        }

        public int ParkId { get; set; }
        public int StateId { get; set; }
        [Required]
        public string ParkName { get; set; }
        [Required]
        public bool ParkNational { get; set; }

        [JsonIgnore]
        public virtual State States { get; set;}
    }
}