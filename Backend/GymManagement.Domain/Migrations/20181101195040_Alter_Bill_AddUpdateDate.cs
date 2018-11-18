using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagement.Domain.Migrations
{
    public partial class Alter_Bill_AddUpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Bill",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Bill");
        }
    }
}
