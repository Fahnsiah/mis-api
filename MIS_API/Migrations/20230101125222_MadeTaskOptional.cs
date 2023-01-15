using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIS_API.Migrations
{
    public partial class MadeTaskOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Tasks_TaskId",
                table: "RolePermissions");

            migrationBuilder.AlterColumn<string>(
                name: "TaskId",
                table: "RolePermissions",
                type: "nvarchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "PasswordHash", "Verified" },
                values: new object[] { new DateTime(2023, 1, 1, 12, 52, 21, 782, DateTimeKind.Local).AddTicks(1633), "$2b$10$6j/c3A2MlTZ1GmBhsvnQo.R0eNiDJqMYlIcNsf2wsfeY.Ln/VAVV2", new DateTime(2023, 1, 1, 12, 52, 21, 782, DateTimeKind.Local).AddTicks(1887) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 1, 12, 52, 21, 650, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Tasks_TaskId",
                table: "RolePermissions",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Tasks_TaskId",
                table: "RolePermissions");

            migrationBuilder.AlterColumn<string>(
                name: "TaskId",
                table: "RolePermissions",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "PasswordHash", "Verified" },
                values: new object[] { new DateTime(2022, 12, 30, 16, 32, 41, 459, DateTimeKind.Local).AddTicks(7750), "$2b$10$/K15VSXJTppgcfXPHNIQs.5EtHUV4HtrG1x4xmR2KX.TQLTTAcDkG", new DateTime(2022, 12, 30, 16, 32, 41, 459, DateTimeKind.Local).AddTicks(7997) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 30, 16, 32, 41, 457, DateTimeKind.Local).AddTicks(5271));

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Tasks_TaskId",
                table: "RolePermissions",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
