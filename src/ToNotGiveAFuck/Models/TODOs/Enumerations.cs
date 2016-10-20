using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToNotGiveAFuck.Models.TODOs
{
    public static class Enumerations
    {
        public enum Status
        {
            Started = 0,
            Finished = 1,
        }
        public enum Type
        {
            Ordinary,
            Chain
        }
    }
}
