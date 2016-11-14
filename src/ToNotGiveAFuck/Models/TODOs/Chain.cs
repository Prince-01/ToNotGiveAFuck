using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToNotGiveAFuck.Models.TODOs
{
    public class Chain
    {
        public int ChainId { get; set; }
        public string ChainName { get; set; }
        public virtual List<ChainsTodos> Todos { get; set; }
    }
}
