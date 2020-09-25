using Microsoft.EntityFrameworkCore.Migrations;

namespace PonderingProgrammer.Dajumble.Web.Data.Migrations
{
    public partial class RenamedItemTypeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Item",
                table: "ContentItem",
                newName: "ItemType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemType",
                table: "ContentItem",
                newName: "Item");
        }
    }
}
