using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSystem.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoteItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VoteId = table.Column<Guid>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    IsMultiple = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteItem_Votes_VoteId",
                        column: x => x.VoteId,
                        principalTable: "Votes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteItem_VoteId",
                table: "VoteItem",
                column: "VoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoteItem");

            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
