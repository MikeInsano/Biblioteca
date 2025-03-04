using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaBolonMiguel.Migrations
{
    /// <inheritdoc />
    public partial class CambioRelacionesUnoAUno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_PkAutor",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editorials_PkEditorial",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Generos_PkGenero",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_PkAutor",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_PkEditorial",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_PkGenero",
                table: "Libros");

            migrationBuilder.AlterColumn<int>(
                name: "PkGenero",
                table: "Libros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PkEditorial",
                table: "Libros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PkAutor",
                table: "Libros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PkAutor",
                table: "Libros",
                column: "PkAutor",
                unique: true,
                filter: "[PkAutor] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PkEditorial",
                table: "Libros",
                column: "PkEditorial",
                unique: true,
                filter: "[PkEditorial] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PkGenero",
                table: "Libros",
                column: "PkGenero",
                unique: true,
                filter: "[PkGenero] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_PkAutor",
                table: "Libros",
                column: "PkAutor",
                principalTable: "Autores",
                principalColumn: "PkAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editorials_PkEditorial",
                table: "Libros",
                column: "PkEditorial",
                principalTable: "Editorials",
                principalColumn: "PkEditorial");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Generos_PkGenero",
                table: "Libros",
                column: "PkGenero",
                principalTable: "Generos",
                principalColumn: "PkGenero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_PkAutor",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editorials_PkEditorial",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Generos_PkGenero",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_PkAutor",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_PkEditorial",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_PkGenero",
                table: "Libros");

            migrationBuilder.AlterColumn<int>(
                name: "PkGenero",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PkEditorial",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PkAutor",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PkAutor",
                table: "Libros",
                column: "PkAutor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PkEditorial",
                table: "Libros",
                column: "PkEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PkGenero",
                table: "Libros",
                column: "PkGenero");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_PkAutor",
                table: "Libros",
                column: "PkAutor",
                principalTable: "Autores",
                principalColumn: "PkAutor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editorials_PkEditorial",
                table: "Libros",
                column: "PkEditorial",
                principalTable: "Editorials",
                principalColumn: "PkEditorial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Generos_PkGenero",
                table: "Libros",
                column: "PkGenero",
                principalTable: "Generos",
                principalColumn: "PkGenero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
