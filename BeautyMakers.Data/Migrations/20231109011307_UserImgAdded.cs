using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeautyMakers.Data.Migrations
{
    public partial class UserImgAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beautyProfessionalUsers_BeautyProfessionals_BeautyProfessio~",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_beautyProfessionalUsers_Users_UserId1",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_beautyProfessionalUsers",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropIndex(
                name: "IX_beautyProfessionalUsers_BeautyProfessionalId1",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropIndex(
                name: "IX_beautyProfessionalUsers_UserId1",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropColumn(
                name: "BeautyProfessionalId1",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "beautyProfessionalUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserImg",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "beautyProfessionalUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BeautyProfessionalId",
                table: "beautyProfessionalUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "beautyProfessionalUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalImage",
                table: "BeautyProfessionals",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_beautyProfessionalUsers",
                table: "beautyProfessionalUsers",
                columns: new[] { "BeautyProfessionalId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_beautyProfessionalUsers_UserId",
                table: "beautyProfessionalUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_beautyProfessionalUsers_BeautyProfessionals_BeautyProfessio~",
                table: "beautyProfessionalUsers",
                column: "BeautyProfessionalId",
                principalTable: "BeautyProfessionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_beautyProfessionalUsers_Users_UserId",
                table: "beautyProfessionalUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beautyProfessionalUsers_BeautyProfessionals_BeautyProfessio~",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_beautyProfessionalUsers_Users_UserId",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_beautyProfessionalUsers",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropIndex(
                name: "IX_beautyProfessionalUsers_UserId",
                table: "beautyProfessionalUsers");

            migrationBuilder.DropColumn(
                name: "UserImg",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfessionalImage",
                table: "BeautyProfessionals");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "beautyProfessionalUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "beautyProfessionalUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BeautyProfessionalId",
                table: "beautyProfessionalUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "BeautyProfessionalId1",
                table: "beautyProfessionalUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "beautyProfessionalUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_beautyProfessionalUsers",
                table: "beautyProfessionalUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_beautyProfessionalUsers_BeautyProfessionalId1",
                table: "beautyProfessionalUsers",
                column: "BeautyProfessionalId1");

            migrationBuilder.CreateIndex(
                name: "IX_beautyProfessionalUsers_UserId1",
                table: "beautyProfessionalUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_beautyProfessionalUsers_BeautyProfessionals_BeautyProfessio~",
                table: "beautyProfessionalUsers",
                column: "BeautyProfessionalId1",
                principalTable: "BeautyProfessionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_beautyProfessionalUsers_Users_UserId1",
                table: "beautyProfessionalUsers",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
