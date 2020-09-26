using Microsoft.EntityFrameworkCore.Migrations;

namespace PonderingProgrammer.Dajumble.Web.Data.Migrations
{
    public partial class AddItemRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    SourceId = table.Column<string>(nullable: false),
                    TargetId = table.Column<string>(nullable: false),
                    RelationType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation", x => new { x.SourceId, x.TargetId });
                    table.ForeignKey(
                        name: "FK_Relation_ContentItem_SourceId",
                        column: x => x.SourceId,
                        principalTable: "ContentItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relation_ContentItem_TargetId",
                        column: x => x.TargetId,
                        principalTable: "ContentItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relation_TargetId",
                table: "Relation",
                column: "TargetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relation");
        }
    }
}
