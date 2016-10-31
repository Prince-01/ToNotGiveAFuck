using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToNotGiveAFuck.Models.TODOs
{
    public class ChainsTodos
    {
        [Key, Column(Order = 1)]
        public int ChainID { get; set; }
        public virtual Chain Chain { get; set; }
        [Key, Column(Order = 2)]
        public Guid TodoId { get; set; }
        public virtual TODO Todo { get; set; }
        public int Position { get; set; }

    }
}
