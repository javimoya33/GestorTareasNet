using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorTareas.Migrations
{
    /// <inheritdoc />
    public partial class Encargados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encargados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encargados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncargadosTareas",
                columns: table => new
                {
                    EncargadoId = table.Column<int>(type: "int", nullable: false),
                    TareaId = table.Column<int>(type: "int", nullable: false),
                    EncargadosId = table.Column<int>(type: "int", nullable: true),
                    TareasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncargadosTareas", x => new { x.EncargadoId, x.TareaId });
                    table.ForeignKey(
                        name: "FK_EncargadosTareas_Encargados_EncargadosId",
                        column: x => x.EncargadosId,
                        principalTable: "Encargados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EncargadosTareas_Tareas_TareasId",
                        column: x => x.TareasId,
                        principalTable: "Tareas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncargadosTareas_EncargadosId",
                table: "EncargadosTareas",
                column: "EncargadosId");

            migrationBuilder.CreateIndex(
                name: "IX_EncargadosTareas_TareasId",
                table: "EncargadosTareas",
                column: "TareasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncargadosTareas");

            migrationBuilder.DropTable(
                name: "Encargados");
        }
    }
}
