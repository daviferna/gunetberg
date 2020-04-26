using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gunetberg.Infrastructure.Migrations
{
    public partial class ProfilePictureToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePicture",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");
        }
    }
}
