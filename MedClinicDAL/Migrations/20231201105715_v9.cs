using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedClinicDAL.Migrations
{
	/// <inheritdoc />
	public partial class v9 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Slots_Doctors_DoctorID",
				table: "Slots");

			migrationBuilder.DropColumn(
				name: "Shift",
				table: "Slots");

			migrationBuilder.RenameColumn(
				name: "DoctorID",
				table: "Slots",
				newName: "DoctorId");

			migrationBuilder.RenameIndex(
				name: "IX_Slots_DoctorID",
				table: "Slots",
				newName: "IX_Slots_DoctorId");

			migrationBuilder.AlterColumn<Guid>(
				name: "RecordId",
				table: "Slots",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier");

			migrationBuilder.AddForeignKey(
				name: "FK_Slots_Doctors_DoctorId",
				table: "Slots",
				column: "DoctorId",
				principalTable: "Doctors",
				principalColumn: "ID",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Slots_Doctors_DoctorId",
				table: "Slots");

			migrationBuilder.RenameColumn(
				name: "DoctorId",
				table: "Slots",
				newName: "DoctorID");

			migrationBuilder.RenameIndex(
				name: "IX_Slots_DoctorId",
				table: "Slots",
				newName: "IX_Slots_DoctorID");

			migrationBuilder.AddColumn<int>(
				name: "Shift",
				table: "Slots",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddForeignKey(
				name: "FK_Slots_Doctors_DoctorID",
				table: "Slots",
				column: "DoctorID",
				principalTable: "Doctors",
				principalColumn: "ID",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
