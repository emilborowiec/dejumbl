using Microsoft.EntityFrameworkCore.Migrations;

namespace PonderingProgrammer.Dajumble.Web.Data.Migrations
{
    public partial class AddContentItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentItem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Item = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ContextId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentItem_Contexts_ContextId",
                        column: x => x.ContextId,
                        principalTable: "Contexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentItem_ContextId",
                table: "ContentItem",
                column: "ContextId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentItem");
        }
    }
}
