using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorTareas.Migrations
{
    /// <inheritdoc />
    public partial class Proyectos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTareasTareas");

            migrationBuilder.AddColumn<int>(
                name: "TareaId",
                table: "SubTareas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubTareas_TareaId",
                table: "SubTareas",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTareas_Tareas_TareaId",
                table: "SubTareas",
                column: "TareaId",
                principalTable: "Tareas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTareas_Tareas_TareaId",
                table: "SubTareas");

            migrationBuilder.DropIndex(
                name: "IX_SubTareas_TareaId",
                table: "SubTareas");

            migrationBuilder.DropColumn(
                name: "TareaId",
                table: "SubTareas");

            migrationBuilder.CreateTable(
                name: "SubTareasTareas",
                columns: table => new
                {
                    SubTareaId = table.Column<int>(type: "int", nullable: false),
                    TareaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTareasTareas", x => new { x.SubTareaId, x.TareaId });
                    table.ForeignKey(
                        name: "FK_SubTareasTareas_SubTareas_SubTareaId",
                        column: x => x.SubTareaId,
                        principalTable: "SubTareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubTareasTareas_Tareas_TareaId",
                        column: x => x.TareaId,
                        principalTable: "Tareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTareasTareas_TareaId",
                table: "SubTareasTareas",
                column: "TareaId");
        }
    }
}
