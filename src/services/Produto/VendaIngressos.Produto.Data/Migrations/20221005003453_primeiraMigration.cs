using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaIngressos.Produto.Data.Migrations
{
    public partial class primeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Telefone = table.Column<string>(type: "CHAR(11)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sigla = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeMunicipio = table.Column<string>(type: "Varchar(100)", nullable: true),
                    UfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Uf_UfId",
                        column: x => x.UfId,
                        principalTable: "Uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Rua = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "Varchar(100)", nullable: true),
                    MunicipioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowHouse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "Varchar(100)", nullable: true),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowHouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowHouse_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeIngresso = table.Column<int>(type: "INT", nullable: false),
                    Poster = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    TipoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowHouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atracoes_Organizadores_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atracoes_ShowHouse_ShowHouseId",
                        column: x => x.ShowHouseId,
                        principalTable: "ShowHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Uf",
                columns: new[] { "Id", "CreateAt", "Nome", "Sigla" },
                values: new object[,]
                {
                    { new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7152), "Para", "PA" },
                    { new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7308), "Rondonia", "RO" },
                    { new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7332), "Distrito Federal", "DF" },
                    { new Guid("20792100-80af-49a8-8195-f7c36441c38d"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7135), "Espirito Santo", "ES" },
                    { new Guid("275002db-aa62-444e-a179-b801583c3568"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7185), "Piaui", "PI" },
                    { new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7127), "Amazonas", "AM" },
                    { new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7132), "Ceara", "CE" },
                    { new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7130), "Bahia", "BA" },
                    { new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7188), "Rio de Janeiro", "RJ" },
                    { new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7149), "Minas Gerais", "MG" },
                    { new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7183), "Pernambuco", "PE" },
                    { new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7124), "Amapa", "AP" },
                    { new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7323), "Sao Paulo", "SP" },
                    { new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7193), "Rio Grande do Sul", "RS" },
                    { new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7326), "Sergipe", "SE" },
                    { new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7141), "Maranhao", "MA" },
                    { new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), new DateTime(2022, 10, 5, 0, 34, 53, 439, DateTimeKind.Utc).AddTicks(7099), "Acre", "AC" },
                    { new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7143), "Mato Grosso", "MT" },
                    { new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7329), "Tocantins", "TO" },
                    { new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7138), "Goias", "GO" },
                    { new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7110), "Alagoas", "AL" },
                    { new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7315), "Roraima", "RR" },
                    { new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7146), "Mato Grosso do Sul", "MS" },
                    { new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7155), "Paraiba", "PB" },
                    { new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7320), "Santa Catarina", "SC" },
                    { new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7191), "Rio Grande do Norte", "RN" },
                    { new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), new DateTime(2022, 10, 4, 21, 34, 53, 439, DateTimeKind.Local).AddTicks(7178), "Parana", "PR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atracoes_OrganizadorId",
                table: "Atracoes",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Atracoes_ShowHouseId",
                table: "Atracoes",
                column: "ShowHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_MunicipioId",
                table: "Endereco",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_UfId",
                table: "Municipio",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowHouse_EnderecoId",
                table: "ShowHouse",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atracoes");

            migrationBuilder.DropTable(
                name: "Organizadores");

            migrationBuilder.DropTable(
                name: "ShowHouse");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Uf");
        }
    }
}
