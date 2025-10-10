using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBCategoria_TBDespesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCategoria_TBDespesa_TBDespesa_DespesasId",
                table: "TBCategoria_TBDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBDespesa",
                table: "TBDespesa");

            migrationBuilder.RenameTable(
                name: "TBDespesa",
                newName: "Despesas");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Despesas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCategoria_TBDespesa_Despesas_DespesasId",
                table: "TBCategoria_TBDespesa",
                column: "DespesasId",
                principalTable: "Despesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCategoria_TBDespesa_Despesas_DespesasId",
                table: "TBCategoria_TBDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas");

            migrationBuilder.RenameTable(
                name: "Despesas",
                newName: "TBDespesa");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TBDespesa",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBDespesa",
                table: "TBDespesa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCategoria_TBDespesa_TBDespesa_DespesasId",
                table: "TBCategoria_TBDespesa",
                column: "DespesasId",
                principalTable: "TBDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
