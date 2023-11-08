using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyMakers.Data.Migrations
{
    public partial class ProblemDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastWorks_BeautyProfessionals_BeautyProfessionalId",
                table: "PastWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Salons_BeautyProfessionals_OwnerId",
                table: "Salons");

            migrationBuilder.DropIndex(
                name: "IX_Salons_OwnerId",
                table: "Salons");

            migrationBuilder.AddColumn<long>(
                name: "SalonId",
                table: "BeautyProfessionals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_BeautyProfessionals_SalonId",
                table: "BeautyProfessionals",
                column: "SalonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BeautyProfessionals_Salons_SalonId",
                table: "BeautyProfessionals",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastWorks_BeautyProfessionals_BeautyProfessionalId",
                table: "PastWorks",
                column: "BeautyProfessionalId",
                principalTable: "BeautyProfessionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeautyProfessionals_Salons_SalonId",
                table: "BeautyProfessionals");

            migrationBuilder.DropForeignKey(
                name: "FK_PastWorks_BeautyProfessionals_BeautyProfessionalId",
                table: "PastWorks");

            migrationBuilder.DropIndex(
                name: "IX_BeautyProfessionals_SalonId",
                table: "BeautyProfessionals");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "BeautyProfessionals");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_OwnerId",
                table: "Salons",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PastWorks_BeautyProfessionals_BeautyProfessionalId",
                table: "PastWorks",
                column: "BeautyProfessionalId",
                principalTable: "BeautyProfessionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salons_BeautyProfessionals_OwnerId",
                table: "Salons",
                column: "OwnerId",
                principalTable: "BeautyProfessionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
