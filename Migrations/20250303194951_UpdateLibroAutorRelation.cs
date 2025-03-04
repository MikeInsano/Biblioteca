using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaBolonMiguel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLibroAutorRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Libros_PkAutor",
                table: "Libros");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PkAutor",
                table: "Libros",
                column: "PkAutor",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Libros_PkAutor",
                table: "Libros");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PkAutor",
                table: "Libros",
                column: "PkAutor");
        }
    }
}
