using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ToNotGiveAFuck.Models;

namespace ToNotGiveAFuck.Migrations
{
    [DbContext(typeof(ToNotGiveAFuckContext))]
    [Migration("20161017170710_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToNotGiveAFuck.Models.TODOs.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ToNotGiveAFuck.Models.TODOs.TODO", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Priority");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.Property<DateTime>("StatusChangeDate");

                    b.HasKey("TodoId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TODO");
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
