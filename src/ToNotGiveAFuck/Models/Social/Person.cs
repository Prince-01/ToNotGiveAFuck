using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToNotGiveAFuck.Models.TODOs;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.Social
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        public string Name { get; set; }
    }
}
