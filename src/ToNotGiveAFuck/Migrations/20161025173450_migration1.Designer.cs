using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ToNotGiveAFuck.Models;

namespace ToNotGiveAFuck.Migrations
{
    [DbContext(typeof(ToNotGiveAFuckContext))]
    [Migration("20161025173450_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToNotGiveAFuck.Models.Shared.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("Person");

                    b.Property<Guid>("PinnedToId");

                    b.Property<string>("Text");

                    b.Property<Guid?>("TodoId");

                    b.HasKey("CommentId");

                    b.HasIndex("TodoId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.Shared.PersonClaimsAbout", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("PinnedToId");

                    b.Property<int>("Privilege");

                    b.Property<Guid?>("TodoId");

                    b.HasKey("UserId", "PinnedToId");

                    b.HasIndex("TodoId");

                    b.ToTable("PersonClaimsAbout");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.Social.Person", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.TODOs.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.TODOs.StatusChange", b =>
                {
                    b.Property<Guid>("TodoId");

                    b.Property<DateTime>("ChangeDate");

                    b.Property<int>("Status");

                    b.HasKey("TodoId", "ChangeDate");

                    b.HasIndex("TodoId");

                    b.ToTable("StatusChange");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.TODOs.TODO", b =>
                {
                    b.Property<Guid>("TodoId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanBeStartedBefore");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime?>("Deadline");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Priority");

                    b.Property<DateTime?>("StartDate");

                    b.Property<int>("Status");

                    b.Property<DateTime>("StatusChangeDate");

                    b.Property<int>("Type");

                    b.HasKey("TodoId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TODO");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.Shared.Comment", b =>
                {
                    b.HasOne("ToNotGiveAFuck.Models.TODOs.TODO")
                        .WithMany("Comments")
                        .HasForeignKey("TodoId");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.Shared.PersonClaimsAbout", b =>
                {
                    b.HasOne("ToNotGiveAFuck.Models.TODOs.TODO")
                        .WithMany("Involved")
                        .HasForeignKey("TodoId");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.TODOs.StatusChange", b =>
                {
                    b.HasOne("ToNotGiveAFuck.Models.TODOs.TODO", "Todo")
                        .WithMany("StatusHistory")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.TODOs.TODO", b =>
                {
                    b.HasOne("ToNotGiveAFuck.Models.TODOs.Category", "Category")
                        .WithMany("Todos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
