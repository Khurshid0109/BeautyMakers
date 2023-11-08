using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyMakers.Data.Migrations
{
    public partial class AppointmentResultChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "AppointmentServices");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AppointmentServices",
                newName: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "AppointmentServices",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AppointmentServices");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "AppointmentServices",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "AppointmentServices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Appointments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
