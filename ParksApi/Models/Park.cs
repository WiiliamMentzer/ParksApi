using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
    public class Park
    {
        public Park()
        {
          this.JoinStates = new HashSet<StatePark>();
        }

        public int ParkId { get; set; }
        [Required]
        public string ParkName { get; set; }

        public virtual ICollection<StatePark> JoinStates { get; }
    }
}