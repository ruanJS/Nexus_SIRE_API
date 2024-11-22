using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIRE_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM551096");

            migrationBuilder.CreateTable(
                name: "TB_CONSUMOS",
                schema: "RM551096",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    VALOR = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DATA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONSUMOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_DISPOSITIVO",
                schema: "RM551096",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TIPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SERIAL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DISPOSITIVO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_RELATORIO",
                schema: "RM551096",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITULO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DATAGERACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RELATORIO", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONSUMOS",
                schema: "RM551096");

            migrationBuilder.DropTable(
                name: "TB_DISPOSITIVO",
                schema: "RM551096");

            migrationBuilder.DropTable(
                name: "TB_RELATORIO",
                schema: "RM551096");
        }
    }
}
