using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.Shared
{
    public class PersonClaimsAbout
    {
        [Key, Column(Order = 1)]
        public Guid UserId { get; set; }
        [Key, Column(Order = 2)]
        public Guid PinnedToId { get; set; }
        public Priviliges Privilege { get; set; }
    }
}