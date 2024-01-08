using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionClasesGim.Migrations
{
    public partial class TrabajoProgramacion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    clase_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clase_nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    clase_fechahorario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clase_capacidadMax = table.Column<int>(type: "int", nullable: false),
                    clase_cupos = table.Column<int>(type: "int", nullable: false),
                    clase_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.clase_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovs",
                columns: table => new
                {
                    tipoMov_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoMov_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoMov_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovs", x => x.tipoMov_id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_dni = table.Column<int>(type: "int", nullable: false),
                    usuario_clave = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    usuario_nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    usuario_apellido = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    usuario_activo = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alumno_fechainscripcion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historiales",
                columns: table => new
                {
                    historial_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    clase_id = table.Column<int>(type: "int", nullable: false),
                    tipoMov_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiales", x => x.historial_id);
                    table.ForeignKey(
                        name: "FK_Historiales_Clases_clase_id",
                        column: x => x.clase_id,
                        principalTable: "Clases",
                        principalColumn: "clase_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiales_TipoMovs_tipoMov_id",
                        column: x => x.tipoMov_id,
                        principalTable: "TipoMovs",
                        principalColumn: "tipoMov_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiales_Usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_activo", "role_description", "role_name" },
                values: new object[,]
                {
                    { 1, true, "Admin", "Admin" },
                    { 2, true, "Alumno", "Alumno" }
                });

            migrationBuilder.InsertData(
                table: "TipoMovs",
                columns: new[] { "tipoMov_id", "tipoMov_activo", "tipoMov_descripcion" },
                values: new object[,]
                {
                    { 1, false, "Inscripcion" },
                    { 2, false, "Cancelacion" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "usuario_id", "usuario_activo", "usuario_apellido", "usuario_clave", "Discriminator", "usuario_dni", "usuario_nombre", "role_id" },
                values: new object[] { 1, true, "Scaglione", "1234", "Usuario", 41826520, "Franco", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_clase_id",
                table: "Historiales",
                column: "clase_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_tipoMov_id",
                table: "Historiales",
                column: "tipoMov_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_usuario_id",
                table: "Historiales",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_role_id",
                table: "Usuario",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historiales");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "TipoMovs");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
