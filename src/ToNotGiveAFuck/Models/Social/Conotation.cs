using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.Social
{
    public class Conotation
    {
        [Key, Column(Order = 1)]
        public Guid Person1Id { get; set; }
        public virtual Person Person1 { get; set; }
        [Key, Column(Order = 2)]
        public Guid Person2Id { get; set; }
        public virtual Person Person2 { get; set; }
        public ConotationKinds Kind { get; set; }
    }
}
