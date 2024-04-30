using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedClinicDAL.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specializations_SpecializationID",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "SpecializationID",
                table: "Doctors",
                newName: "SpecializationId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SpecializationID",
                table: "Doctors",
                newName: "IX_Doctors_SpecializationId");

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Slots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LinkPhoto",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportId",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specializations_SpecializationId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "LinkPhoto",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "SpecializationId",
                table: "Doctors",
                newName: "SpecializationID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                newName: "IX_Doctors_SpecializationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specializations_SpecializationID",
                table: "Doctors",
                column: "SpecializationID",
                principalTable: "Specializations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
