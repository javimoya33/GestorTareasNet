using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorTareas.Migrations
{
    /// <inheritdoc />
    public partial class SubTareas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NivelId",
                table: "Tareas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubTareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    Fecha_prevista = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTareas_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TareasSubTareas",
                columns: table => new
                {
                    TareaId = table.Column<int>(type: "int", nullable: false),
                    SubTareasId = table.Column<int>(type: "int", nullable: false),
                    TareasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareasSubTareas", x => new { x.TareaId, x.SubTareasId });
                    table.ForeignKey(
                        name: "FK_TareasSubTareas_SubTareas_SubTareasId",
                        column: x => x.SubTareasId,
                        principalTable: "SubTareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TareasSubTareas_Tareas_TareasId",
                        column: x => x.TareasId,
                        principalTable: "Tareas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_NivelId",
                table: "Tareas",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTareas_EstadoId",
                table: "SubTareas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TareasSubTareas_SubTareasId",
                table: "TareasSubTareas",
                column: "SubTareasId");

            migrationBuilder.CreateIndex(
                name: "IX_TareasSubTareas_TareasId",
                table: "TareasSubTareas",
                column: "TareasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Nivel_NivelId",
                table: "Tareas",
                column: "NivelId",
                principalTable: "Nivel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Nivel_NivelId",
                table: "Tareas");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "TareasSubTareas");

            migrationBuilder.DropTable(
                name: "SubTareas");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_NivelId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "NivelId",
                table: "Tareas");
        }
    }
}
