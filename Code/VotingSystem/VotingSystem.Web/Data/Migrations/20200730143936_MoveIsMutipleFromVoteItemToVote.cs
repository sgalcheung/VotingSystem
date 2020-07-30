using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSystem.Web.Data.Migrations
{
    public partial class MoveIsMutipleFromVoteItemToVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMultiple",
                table: "VoteItem");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateTime",
                table: "Votes",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsMultiple",
                table: "Votes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsMultiple",
                table: "Votes");

            migrationBuilder.AddColumn<bool>(
                name: "IsMultiple",
                table: "VoteItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
