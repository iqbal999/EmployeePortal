using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EP.DataAccess.Migrations
{
    public partial class SmallChangesInEmployeeLeaveModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddBy",
                table: "EmployeeLeaves",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "EmployeeLeaves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "EmployeeLeaves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "EmployeeLeaves",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddBy",
                table: "EmployeeLeaves");

            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "EmployeeLeaves");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "EmployeeLeaves");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "EmployeeLeaves");
        }
    }
}
