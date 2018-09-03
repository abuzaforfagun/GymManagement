using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagement.Domain.Migrations
{
    public partial class AddPersonIdToSampleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samples_Person_PersonId",
                table: "Samples");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Samples",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Samples_Person_PersonId",
                table: "Samples",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samples_Person_PersonId",
                table: "Samples");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Samples",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Samples_Person_PersonId",
                table: "Samples",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
