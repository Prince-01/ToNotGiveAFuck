using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.TODOs
{
    public class StatusChange
    {
        [Key, Column(Order = 1)]
        public Guid TodoId { get; set; }
        public virtual TODO Todo { get; set; }
        [Key, Column(Order = 2)]
        public DateTime ChangeDate { get; set; }
        public Statuses Status { get; set; }
    }
}
