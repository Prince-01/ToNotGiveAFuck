using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToNotGiveAFuck.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TODO",
                columns: table => new
                {
                    TodoId = table.Column<Guid>(nullable: false),
                    CanBeStartedBefore = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusChangeDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TODO", x => x.TodoId);
                    table.ForeignKey(
                        name: "FK_TODO_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Person = table.Column<Guid>(nullable: false),
                    PinnedToId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    TodoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_TODO_TodoId",
                        column: x => x.TodoId,
                        principalTable: "TODO",
                        principalColumn: "TodoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonClaimsAbout",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    PinnedToId = table.Column<Guid>(nullable: false),
                    Privilege = table.Column<int>(nullable: false),
                    TodoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonClaimsAbout", x => new { x.UserId, x.PinnedToId });
                    table.ForeignKey(
                        name: "FK_PersonClaimsAbout_TODO_TodoId",
                        column: x => x.TodoId,
                        principalTable: "TODO",
                        principalColumn: "TodoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusChange",
                columns: table => new
                {
                    TodoId = table.Column<Guid>(nullable: false),
                    ChangeDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusChange", x => new { x.TodoId, x.ChangeDate });
                    table.ForeignKey(
                        name: "FK_StatusChange_TODO_TodoId",
                        column: x => x.TodoId,
                        principalTable: "TODO",
                        principalColumn: "TodoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TodoId",
                table: "Comment",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonClaimsAbout_TodoId",
                table: "PersonClaimsAbout",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusChange_TodoId",
                table: "StatusChange",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_TODO_CategoryId",
                table: "TODO",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "PersonClaimsAbout");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "StatusChange");

            migrationBuilder.DropTable(
                name: "TODO");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
