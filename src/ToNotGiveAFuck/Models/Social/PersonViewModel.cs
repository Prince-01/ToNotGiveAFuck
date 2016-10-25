using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToNotGiveAFuck.Models.TODOs;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Models.Social
{
    public class PersonViewModel
    {
        public Person Person { get; set; }
        public List<Tuple<Priviliges, TODO>> TODOList { get; set; }
    }
}
