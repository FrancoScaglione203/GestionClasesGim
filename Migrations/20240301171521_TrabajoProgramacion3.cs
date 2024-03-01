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
                    clase_imagenUrl = table.Column<string>(type: "VARCHAR(5000)", nullable: false),
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
                name: "Usuarios",
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
                    alumno_fechainscripcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alumno_imagenUrl = table.Column<string>(type: "VARCHAR(5000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_role_id",
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
                        name: "FK_Historiales_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
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
                table: "Usuarios",
                columns: new[] { "usuario_id", "usuario_activo", "usuario_apellido", "usuario_clave", "Discriminator", "usuario_dni", "alumno_fechainscripcion", "usuario_nombre", "role_id", "alumno_imagenUrl" },
                values: new object[,]
                {
                    { 2, true, "Avila", "57bf859ec80d6c0d016be06a0e9694684d53951db5f5e18f72d4e59ee1ac8096", "Alumno", 20587469, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria Luz", 2, " " },
                    { 3, true, "Scaglione", "92aa37811a86fb7e8aec77e26361f1983ce838940a5f3736fc083fa2bf247dc3", "Alumno", 52467894, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalia", 2, " " },
                    { 4, true, "Scaglione", "c808983b806db5d535f1b84ba36510dd8eb6f68d4e31a136143f0c488648c6a9", "Alumno", 97852654, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vicente", 2, " " },
                    { 5, true, "Barisano", "c808983b806db5d535f1b84ba36510dd8eb6f68d4e31a136143f0c488648c6a9", "Alumno", 23451474, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Facundo", 2, " " },
                    { 6, true, "Croce", "ade1bfc7f862a3e28ca044e8c9e32103ea452b62946ae44ecd6076095f2e322d", "Alumno", 56789845, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eliana", 2, " " },
                    { 7, true, "Italia", "ade1bfc7f862a3e28ca044e8c9e32103ea452b62946ae44ecd6076095f2e322d", "Alumno", 32347841, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaqueline", 2, " " },
                    { 8, true, "Lozada", "d167660fe711956a00d3dca7b49b5c95cfd2d40c980b3dadf1af31ba0915d799", "Alumno", 87456548, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jony", 2, " " },
                    { 9, true, "Acosta", "cb096c1ca77084ae25d67db3826eba376c48cf53aa308e30ccf52179628f88e8", "Alumno", 65986563, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claudio", 2, " " },
                    { 10, true, "Garcia", "ade1bfc7f862a3e28ca044e8c9e32103ea452b62946ae44ecd6076095f2e322d", "Alumno", 78981232, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kim", 2, " " },
                    { 11, true, "Vera", "57bf859ec80d6c0d016be06a0e9694684d53951db5f5e18f72d4e59ee1ac8096", "Alumno", 56564564, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ezequiel", 2, " " },
                    { 12, true, "Leoni", "c808983b806db5d535f1b84ba36510dd8eb6f68d4e31a136143f0c488648c6a9", "Alumno", 62616344, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicolas", 2, " " },
                    { 13, true, "Del Olio", "92aa37811a86fb7e8aec77e26361f1983ce838940a5f3736fc083fa2bf247dc3", "Alumno", 56111243, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marina", 2, " " },
                    { 14, true, "Ballarini", "08e9366a7aa060344c3c9eb571fb3d49157350b90c89c6905e83767961a5d714", "Alumno", 64445121, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manuel", 2, " " },
                    { 15, true, "Solimano", "57bf859ec80d6c0d016be06a0e9694684d53951db5f5e18f72d4e59ee1ac8096", "Alumno", 33265561, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriela", 2, " " }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "usuario_id", "usuario_activo", "usuario_apellido", "usuario_clave", "Discriminator", "usuario_dni", "usuario_nombre", "role_id" },
                values: new object[] { 1, true, "Scaglione", "caf2283ef018112cc755da6f4452473bd8ffce41baf2e685c0583f769da63eb5", "Usuario", 41826520, "Franco", 1 });

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
                name: "IX_Usuarios_role_id",
                table: "Usuarios",
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
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
