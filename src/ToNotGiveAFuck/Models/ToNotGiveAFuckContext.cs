using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToNotGiveAFuck.Models.TODOs;
using ToNotGiveAFuck.Models.Shared;
using ToNotGiveAFuck.Models.Social;

namespace ToNotGiveAFuck.Models
{
    public class ToNotGiveAFuckContext : DbContext
    {
        public ToNotGiveAFuckContext(DbContextOptions<ToNotGiveAFuckContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonClaimsAbout>()
                .HasKey(p => new { p.UserId, p.PinnedToId });
            modelBuilder.Entity<StatusChange>()
                .HasKey(p => new { p.TodoId, p.ChangeDate });
            modelBuilder.Entity<ChainsTodos>()
                .HasKey(p => new { p.ChainID, p.TodoId });
            modelBuilder.Entity<Conotation>()
                .HasKey(p => new { p.Person1Id, p.Person2Id });
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<TODO> TODO { get; set; }
        public DbSet<StatusChange> StatusChange { get; set; }
        public DbSet<PersonClaimsAbout> PersonClaimsAbout { get; set; }
        public DbSet<Chain> Chain { get; set; }
        public DbSet<ChainsTodos> ChainsTodos { get; set; }
        public DbSet<Conotation> Conotation { get; set; }
    }
}
