using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gunetberg.Infrastructure.Migrations
{
    public partial class AddingFeaturedDateToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FeaturedDate",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeaturedDate",
                table: "Posts");
        }
    }
}
