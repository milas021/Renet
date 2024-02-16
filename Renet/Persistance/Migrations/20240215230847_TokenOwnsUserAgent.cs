using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class TokenOwnsUserAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_UserAgents_UserAgentId",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAgents",
                table: "UserAgents");

            migrationBuilder.RenameTable(
                name: "UserAgents",
                newName: "UserAgent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAgent",
                table: "UserAgent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_UserAgent_UserAgentId",
                table: "Tokens",
                column: "UserAgentId",
                principalTable: "UserAgent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_UserAgent_UserAgentId",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAgent",
                table: "UserAgent");

            migrationBuilder.RenameTable(
                name: "UserAgent",
                newName: "UserAgents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAgents",
                table: "UserAgents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_UserAgents_UserAgentId",
                table: "Tokens",
                column: "UserAgentId",
                principalTable: "UserAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
