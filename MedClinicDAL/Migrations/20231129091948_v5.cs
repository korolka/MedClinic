using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedClinicDAL.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            


            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "Records");

            migrationBuilder.AddColumn<Guid>(
                name: "RecordId",
                table: "Slots",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Slots_RecordId",
                table: "Slots",
                column: "RecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Records_RecordId",
                table: "Slots",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Records_RecordId",
                table: "Slots");

            migrationBuilder.DropIndex(
                name: "IX_Slots_RecordId",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Slots");

            migrationBuilder.AddColumn<Guid>(
                name: "SlotId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Records_SlotId",
                table: "Records",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Slots_SlotId",
                table: "Records",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
