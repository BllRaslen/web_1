using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigratio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_kullanicis",
                table: "kullanicis");

            migrationBuilder.RenameTable(
                name: "kullanicis",
                newName: "kullanici");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kullanici",
                table: "kullanici",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_kullanici",
                table: "kullanici");

            migrationBuilder.RenameTable(
                name: "kullanici",
                newName: "kullanicis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kullanicis",
                table: "kullanicis",
                column: "Id");
        }
    }
}
