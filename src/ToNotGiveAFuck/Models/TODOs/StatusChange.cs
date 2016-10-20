using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.TODOs
{
    public class StatusChange
    {
        public int TodoId { get; set; }
        public virtual TODO Todo { get; set; }
        public DateTime ChangeDate { get; set; }
        public Status Status { get; set; }
    }
}
