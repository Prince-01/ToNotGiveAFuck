using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.Shared
{
    public class Person
    {
        public Guid UserId { get; set; }
        public Priviliges Privilege { get; set; }
        public Guid PinnedToId { get; set; }
    }
}
