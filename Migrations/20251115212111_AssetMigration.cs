using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INVENTAR.IO.Migrations
{
    /// <inheritdoc />
    public partial class AssetMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColaboratorId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_Colaborators_ColaboratorId",
                        column: x => x.ColaboratorId,
                        principalTable: "Colaborators",
                        principalColumn: "ColaboratorId");
                    table.ForeignKey(
                        name: "FK_Assets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetId",
                table: "Assets",
                column: "AssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ColaboratorId",
                table: "Assets",
                column: "ColaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ProductId",
                table: "Assets",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
