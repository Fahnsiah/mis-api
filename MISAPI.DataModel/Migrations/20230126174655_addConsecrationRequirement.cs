using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MISAPI.DataModel.Migrations
{
    public partial class addConsecrationRequirement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ConsecrationArticles_ArticleId",
                table: "ConsecrationArticles");

            migrationBuilder.CreateTable(
                name: "ConsecrationRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinAdultBrother = table.Column<int>(type: "int", nullable: false),
                    MinAdultSister = table.Column<int>(type: "int", nullable: false),
                    MinJrBrother = table.Column<int>(type: "int", nullable: false),
                    MinJrSister = table.Column<int>(type: "int", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    UserLogId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateLogId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsecrationRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsecrationRequirements_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PasswordHash", "Verified" },
                values: new object[] { new DateTime(2023, 1, 26, 17, 46, 55, 356, DateTimeKind.Local).AddTicks(1074), "$2a$11$iaVeo8lVWgA1ffeAjv2rQeOoe2nX0KwPX0wv4NGXH5OzeIbffqnfa", new DateTime(2023, 1, 26, 17, 46, 55, 356, DateTimeKind.Local).AddTicks(1227) });

            migrationBuilder.UpdateData(
                table: "Councils",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 26, 17, 46, 55, 355, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 26, 17, 46, 55, 355, DateTimeKind.Local).AddTicks(5278));

            migrationBuilder.CreateIndex(
                name: "IX_ConsecrationArticles_ArticleId",
                table: "ConsecrationArticles",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsecrationRequirements_CurrencyId",
                table: "ConsecrationRequirements",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsecrationRequirements");

            migrationBuilder.DropIndex(
                name: "IX_ConsecrationArticles_ArticleId",
                table: "ConsecrationArticles");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PasswordHash", "Verified" },
                values: new object[] { new DateTime(2023, 1, 25, 17, 54, 52, 769, DateTimeKind.Local).AddTicks(7019), "$2a$11$ckHe3fTX.yjGkKNYpJkKcORddDf6a/mpcwVyMNDtaRmQV8nc5PkHG", new DateTime(2023, 1, 25, 17, 54, 52, 769, DateTimeKind.Local).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "Councils",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 25, 17, 54, 52, 768, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 1, 25, 17, 54, 52, 768, DateTimeKind.Local).AddTicks(9392));

            migrationBuilder.CreateIndex(
                name: "IX_ConsecrationArticles_ArticleId",
                table: "ConsecrationArticles",
                column: "ArticleId");
        }
    }
}
