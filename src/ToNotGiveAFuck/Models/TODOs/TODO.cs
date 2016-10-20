using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.TODOs
{
    public class TODO
    {
        public int TodoId { get; set; }
        [Required()]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int Priority { get; set; }
        public Enumerations.Type Type { get; set; }
        public Status Status { get; set; }
        public List<StatusChange> StatusHistory { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? StartDate { get; set; }
        public bool CanBeStartedBefore { get; set; }
        public DateTime StatusChangeDate { get; set; }
        [Display(AutoGenerateField = false)]
        public string CreatedBy { get; set; }
        public virtual List<string> Administrators { get; set; }
        public virtual List<string> Observers { get; set; }


    }
}
