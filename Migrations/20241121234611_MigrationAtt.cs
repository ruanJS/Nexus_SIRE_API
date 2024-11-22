using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIRE_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM551096");

            migrationBuilder.CreateTable(
                name: "Consumos",
                schema: "RM551096",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Valor = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                schema: "RM551096",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DataGeracao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.ID);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumos",
                schema: "RM551096");

            migrationBuilder.DropTable(
                name: "Relatorios",
                schema: "RM551096");

            migrationBuilder.DropTable(
                name: "TB_DISPOSITIVO",
                schema: "RM551096");
        }
    }
}
