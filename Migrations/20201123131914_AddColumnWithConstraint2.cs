using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class AddColumnWithConstraint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "prop_ctx",
                table: "Blogs",
                sql: "new_property IN ('1', '2')");

            migrationBuilder.AddColumn<string>(
                name: "NewProperty",
                table: "Blogs",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "prop_ctx",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "NewProperty",
                table: "Blogs");
        }
    }
}
