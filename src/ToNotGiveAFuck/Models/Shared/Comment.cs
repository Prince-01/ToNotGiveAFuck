using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToNotGiveAFuck.Models.Shared
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Guid PinnedToId { get; set; }
    }
}
