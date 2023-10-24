using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectOfE_Ticaret.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class entityDüzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAtTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAtTime",
                table: "UserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAtTime",
                table: "UserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAtTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAtTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAtTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateAtTime",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UpdateAtTime",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreateAtTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdateAtTime",
                table: "Roles");
        }
    }
}
