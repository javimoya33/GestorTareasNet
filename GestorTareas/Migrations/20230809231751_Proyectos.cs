using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorTareas.Migrations
{
    /// <inheritdoc />
    public partial class Proyectos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTareas_Estado_EstadoId",
                table: "SubTareas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Nivel_NivelId",
                table: "Tareas");

            migrationBuilder.DropTable(
                name: "CategoriasTareas");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "TareasSubTareas");

            migrationBuilder.AddColumn<int>(
                name: "ProyectoId",
                table: "Tareas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                });

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
                name: "IX_Tareas_ProyectoId",
                table: "Tareas",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_CategoriaId",
                table: "Proyectos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTareasTareas_TareaId",
                table: "SubTareasTareas",
                column: "TareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTareas_Estados_EstadoId",
                table: "SubTareas",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Niveles_NivelId",
                table: "Tareas",
                column: "NivelId",
                principalTable: "Niveles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Proyectos_ProyectoId",
                table: "Tareas",
                column: "ProyectoId",
                principalTable: "Proyectos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTareas_Estados_EstadoId",
                table: "SubTareas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Niveles_NivelId",
                table: "Tareas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Proyectos_ProyectoId",
                table: "Tareas");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Niveles");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "SubTareasTareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_ProyectoId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "ProyectoId",
                table: "Tareas");

            migrationBuilder.CreateTable(
                name: "CategoriasTareas",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    TareaId = table.Column<int>(type: "int", nullable: false),
                    CategoriasId = table.Column<int>(type: "int", nullable: true),
                    TareasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasTareas", x => new { x.CategoriaId, x.TareaId });
                    table.ForeignKey(
                        name: "FK_CategoriasTareas_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriasTareas_Tareas_TareasId",
                        column: x => x.TareasId,
                        principalTable: "Tareas",
                        principalColumn: "Id");
                });

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
                name: "IX_CategoriasTareas_CategoriasId",
                table: "CategoriasTareas",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasTareas_TareasId",
                table: "CategoriasTareas",
                column: "TareasId");

            migrationBuilder.CreateIndex(
                name: "IX_TareasSubTareas_SubTareasId",
                table: "TareasSubTareas",
                column: "SubTareasId");

            migrationBuilder.CreateIndex(
                name: "IX_TareasSubTareas_TareasId",
                table: "TareasSubTareas",
                column: "TareasId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTareas_Estado_EstadoId",
                table: "SubTareas",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Nivel_NivelId",
                table: "Tareas",
                column: "NivelId",
                principalTable: "Nivel",
                principalColumn: "Id");
        }
    }
}
