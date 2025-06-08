using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avaliacoes.Migrations
{
    /// <inheritdoc />
    public partial class LastMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinioes_Produtos_produtoid",
                table: "Opinioes");

            migrationBuilder.RenameColumn(
                name: "produtoid",
                table: "Opinioes",
                newName: "Produtoid");

            migrationBuilder.RenameIndex(
                name: "IX_Opinioes_produtoid",
                table: "Opinioes",
                newName: "IX_Opinioes_Produtoid");

            migrationBuilder.AddColumn<string>(
                name: "id_produto",
                table: "Opinioes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinioes_Produtos_Produtoid",
                table: "Opinioes",
                column: "Produtoid",
                principalTable: "Produtos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinioes_Produtos_Produtoid",
                table: "Opinioes");

            migrationBuilder.DropColumn(
                name: "id_produto",
                table: "Opinioes");

            migrationBuilder.RenameColumn(
                name: "Produtoid",
                table: "Opinioes",
                newName: "produtoid");

            migrationBuilder.RenameIndex(
                name: "IX_Opinioes_Produtoid",
                table: "Opinioes",
                newName: "IX_Opinioes_produtoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinioes_Produtos_produtoid",
                table: "Opinioes",
                column: "produtoid",
                principalTable: "Produtos",
                principalColumn: "id");
        }
    }
}
