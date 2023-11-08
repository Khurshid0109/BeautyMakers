using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeautyMakers.Data.Migrations
{
    public partial class JoinTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BeautyProfessionals_BeautyProfessionalId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_CustomerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentId",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PastWorks_BeautyProfessionals_BeautyProfessionalId",
                table: "PastWorks");

            migrationBuilder.DropTable(
                name: "BeautyProfessionalUser");

            migrationBuilder.CreateTable(
                name: "beautyProfessionalUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeautyProfessionalId = table.Column<int>(type: "integer", nullable: false),
                    BeautyProfessionalId1 = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beautyProfessionalUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_beautyProfessionalUsers_BeautyProfessionals_BeautyProfessio~",
                        column: x => x.BeautyProfessionalId1,
                        principalTable: "BeautyProfessionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_beautyProfessionalUsers_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_beautyProfessionalUsers_BeautyProfessionalId1",
                table: "beautyProfessionalUsers",
                column: "BeautyProfessionalId1");

            migrationBuilder.CreateIndex(
                name: "IX_beautyProfessionalUsers_UserId1",
                table: "beautyProfessionalUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BeautyProfessionals_BeautyProfessionalId",
                table: "Appointments",
                column: "BeautyProfessionalId",
                principalTable: "BeautyProfessionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_CustomerId",
                table: "Appointments",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentId",
                table: "AppointmentServices",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastWorks_BeautyProfessionals_BeautyProfessionalId",
                table: "PastWorks",
                column: "BeautyProfessionalId",
                principalTable: "BeautyProfessionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BeautyProfessionals_BeautyProfessionalId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_CustomerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentId",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PastWorks_BeautyProfessionals_BeautyProfessionalId",
                table: "PastWorks");

            migrationBuilder.DropTable(
                name: "beautyProfessionalUsers");

            migrationBuilder.CreateTable(
                name: "BeautyProfessionalUser",
                columns: table => new
                {
                    BeautyProfessionalsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautyProfessionalUser", x => new { x.BeautyProfessionalsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BeautyProfessionalUser_BeautyProfessionals_BeautyProfession~",
                        column: x => x.BeautyProfessionalsId,
                        principalTable: "BeautyProfessionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeautyProfessionalUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeautyProfessionalUser_UsersId",
                table: "BeautyProfessionalUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BeautyProfessionals_BeautyProfessionalId",
                table: "Appointments",
                column: "BeautyProfessionalId",
                principalTable: "BeautyProfessionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_CustomerId",
                table: "Appointments",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentId",
                table: "AppointmentServices",
                column: "AppointmentId",
                principalTable: "Appointments",
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
    }
}
