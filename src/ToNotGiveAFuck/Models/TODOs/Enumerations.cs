using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToNotGiveAFuck.Models.TODOs
{
    public static class Enumerations
    {
        public enum Priviliges
        {
            Follower = 0,
            Doer = 1,

        }
        public enum Statuses
        {
            Started = 0,
            Finished = 1,
        }
        public enum Types
        {
            Ordinary,
            Chain
        }
    }
}
