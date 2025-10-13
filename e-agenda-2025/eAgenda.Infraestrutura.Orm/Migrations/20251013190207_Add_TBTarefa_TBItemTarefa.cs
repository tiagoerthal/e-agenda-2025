using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBTarefa_TBItemTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TBTarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Concluida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBItemTarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Concluido = table.Column<bool>(type: "bit", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBItemTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBItemTarefa_TBTarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "TBTarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBItemTarefa_TarefaId",
                table: "TBItemTarefa",
                column: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCategoria_TBDespesa_TBDespesa_DespesasId",
                table: "TBCategoria_TBDespesa",
                column: "DespesasId",
                principalTable: "TBDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCategoria_TBDespesa_TBDespesa_DespesasId",
                table: "TBCategoria_TBDespesa");

            migrationBuilder.DropTable(
                name: "TBItemTarefa");

            migrationBuilder.DropTable(
                name: "TBTarefa");

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
    }
}
