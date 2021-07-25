using Microsoft.EntityFrameworkCore.Migrations;

namespace JokenpoNerd.Data.Migrations
{
    public partial class adicionando_campos_a_tabela_Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opcao1",
                table: "Log",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Opcao2",
                table: "Log",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opcao1",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Opcao2",
                table: "Log");
        }
    }
}
