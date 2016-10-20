using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToNotGiveAFuck.Models.TODOs;

namespace ToNotGiveAFuck.Models
{
    public class ToNotGiveAFuckContext : DbContext
    {
        public ToNotGiveAFuckContext (DbContextOptions<ToNotGiveAFuckContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<TODO> TODO { get; set; }
    }
}
