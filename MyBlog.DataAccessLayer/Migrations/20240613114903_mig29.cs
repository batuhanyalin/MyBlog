using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccessLayer.Migrations
{
    public partial class mig29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Articles");
        }
    }
}
