using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JokenpoNerd.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opcao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpcaoId1 = table.Column<int>(type: "int", nullable: false),
                    OpcaoId2 = table.Column<int>(type: "int", nullable: false),
                    VencedorId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regra_Opcao_OpcaoId1",
                        column: x => x.OpcaoId1,
                        principalTable: "Opcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regra_Opcao_OpcaoId2",
                        column: x => x.OpcaoId2,
                        principalTable: "Opcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regra_Opcao_VencedorId",
                        column: x => x.VencedorId,
                        principalTable: "Opcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regra_OpcaoId1",
                table: "Regra",
                column: "OpcaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Regra_OpcaoId2",
                table: "Regra",
                column: "OpcaoId2");

            migrationBuilder.CreateIndex(
                name: "IX_Regra_VencedorId",
                table: "Regra",
                column: "VencedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regra");

            migrationBuilder.DropTable(
                name: "Opcao");
        }
    }
}
