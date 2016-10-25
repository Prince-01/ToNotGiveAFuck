using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ToNotGiveAFuck.Models.Shared;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.TODOs
{
    public class TODO
    {
        [Key]
        public Guid TodoId { get; set; }
        [Required()]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int Priority { get; set; }
        public Types Type { get; set; }
        public Statuses Status { get; set; }
        public List<StatusChange> StatusHistory { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? StartDate { get; set; }
        public bool CanBeStartedBefore { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public virtual List<PersonClaimsAbout> Involved { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
