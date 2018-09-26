using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagement.Domain.Migrations
{
    public partial class AlterBill_Rename_BillingDateToUpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BillingDate",
                table: "Bill",
                newName: "UpdateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Bill",
                newName: "BillingDate");
        }
    }
}
