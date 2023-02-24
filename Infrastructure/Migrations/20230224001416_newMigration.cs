using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Customers",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Customers",
                newName: "CreatedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Customers",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Customers",
                newName: "Created");
        }
    }
}
