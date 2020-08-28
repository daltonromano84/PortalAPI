using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(nullable: false),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 250, nullable: false),
                    IdCargo = table.Column<int>(nullable: false),
                    DataAdmissao = table.Column<DateTime>(nullable: false),
                    DataDemissao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
