using Microsoft.EntityFrameworkCore.Migrations;

namespace Gunetberg.Infrastructure.Migrations
{
    public partial class AddingCommentariesToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_Users_AuthorUserId",
                table: "Commentaries");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_Users_AuthorUserId",
                table: "Commentaries",
                column: "AuthorUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_Users_AuthorUserId",
                table: "Commentaries");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_Users_AuthorUserId",
                table: "Commentaries",
                column: "AuthorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
