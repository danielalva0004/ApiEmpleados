using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEmpleados.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NombreEmpleadoUnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                CREATE UNIQUE INDEX "IX_Empleados_Nombre_Normalizado"
                ON "Empleados" (LOWER(BTRIM("Nombre")));
                """
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                DROP INDEX IF EXISTS "IX_Empleados_Nombre_Normalizado";
                """
            );
        }
    }
}
