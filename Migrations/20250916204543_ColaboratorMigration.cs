using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INVENTAR.IO.Migrations
{
    /// <inheritdoc />
    public partial class ColaboratorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaborators",
                columns: table => new
                {
                    ColaboratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboratorName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ColaboratorEmail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborators", x => x.ColaboratorId);
                    table.ForeignKey(
                        name: "FK_Colaborators_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborators_ColaboratorEmail",
                table: "Colaborators",
                column: "ColaboratorEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborators_DepartmentId",
                table: "Colaborators",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborators");
        }
    }
}
