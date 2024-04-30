using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedClinicDAL.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropIndex(
                name: "IX_Records_SlotId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Slots");

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
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Slots_SlotId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_SlotId",
                table: "Records");

            migrationBuilder.AddColumn<Guid>(
                name: "RecordId",
                table: "Slots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Records_SlotId",
                table: "Records",
                column: "SlotId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Slots_SlotId",
                table: "Records",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
