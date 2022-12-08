using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldCupAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Flag = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birth = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorldCup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<ushort>(type: "smallint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldCup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorldCup_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorldCupCountry",
                columns: table => new
                {
                    WorldCupId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Group = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldCupCountry", x => new { x.WorldCupId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_WorldCupCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorldCupCountry_WorldCup_WorldCupId",
                        column: x => x.WorldCupId,
                        principalTable: "WorldCup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorldCupCountryPlayer",
                columns: table => new
                {
                    WorldCupId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldCupCountryPlayer", x => new { x.WorldCupId, x.CountryId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_WorldCupCountryPlayer_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorldCupCountryPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorldCupCountryPlayer_WorldCup_WorldCupId",
                        column: x => x.WorldCupId,
                        principalTable: "WorldCup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Flag", "Name" },
                values: new object[,]
                {
                    { 1, "https://flagpedia.net/data/flags/w580/qa.webp", "Qatar" },
                    { 2, "https://flagpedia.net/data/flags/w580/ec.webp", "Equador" },
                    { 3, "https://flagpedia.net/data/flags/w580/sn.webp", "Senegal" },
                    { 4, "https://flagpedia.net/data/flags/w580/nl.png", "Holanda" },
                    { 5, "https://flagpedia.net/data/flags/w580/gb-eng.png", "Inglaterra" },
                    { 6, "https://flagpedia.net/data/flags/w580/ir.webp", "Irã" },
                    { 7, "https://flagpedia.net/data/flags/w580/us.webp", "EUA" },
                    { 8, "https://flagpedia.net/data/flags/w580/gb-wls.webp", "País de Gales" },
                    { 9, "https://flagpedia.net/data/flags/w580/ar.webp", "Argentina" },
                    { 10, "https://flagpedia.net/data/flags/w580/sa.webp", "Arábia Saudita" },
                    { 11, "https://flagpedia.net/data/flags/w580/mx.webp", "México" },
                    { 12, "https://flagpedia.net/data/flags/w580/pl.png", "Polônia" },
                    { 13, "https://flagpedia.net/data/flags/w580/fr.png", "França" },
                    { 14, "https://flagpedia.net/data/flags/w580/au.webp", "Austrália" },
                    { 15, "https://flagpedia.net/data/flags/w580/dk.webp", "Dinamarca" },
                    { 16, "https://flagpedia.net/data/flags/w580/tn.webp", "Tunísia" },
                    { 17, "https://flagpedia.net/data/flags/w580/es.webp", "Espanha" },
                    { 18, "https://flagpedia.net/data/flags/w580/cr.webp", "Costa Rica" },
                    { 19, "https://flagpedia.net/data/flags/w580/de.png", "Alemanha" },
                    { 20, "https://flagpedia.net/data/flags/w580/jp.webp", "Japão" },
                    { 21, "https://flagpedia.net/data/flags/w580/be.png", "Bélgica" },
                    { 22, "https://flagpedia.net/data/flags/w580/ca.webp", "Canadá" },
                    { 23, "https://flagpedia.net/data/flags/w580/ma.webp", "Marrocos" },
                    { 24, "https://flagpedia.net/data/flags/w580/hr.webp", "Croácia" },
                    { 25, "https://flagpedia.net/data/flags/w580/br.webp", "Brasil" },
                    { 26, "https://flagpedia.net/data/flags/w580/rs.webp", "Sérvia" },
                    { 27, "https://flagpedia.net/data/flags/w580/ch.png", "Suíça" },
                    { 28, "https://flagpedia.net/data/flags/w580/cm.webp", "Camarões" },
                    { 29, "https://flagpedia.net/data/flags/w580/pt.webp", "Portugal" },
                    { 30, "https://flagpedia.net/data/flags/w580/gh.webp", "Gana" },
                    { 31, "https://flagpedia.net/data/flags/w580/uy.webp", "Uruguai" },
                    { 32, "https://flagpedia.net/data/flags/w580/kr.webp", "Coreia do Sul" }
                });

            migrationBuilder.InsertData(
                table: "WorldCup",
                columns: new[] { "Id", "CountryId", "Year" },
                values: new object[] { 1, 1, (ushort)2022 });

            migrationBuilder.InsertData(
                table: "WorldCupCountry",
                columns: new[] { "CountryId", "WorldCupId", "Group" },
                values: new object[,]
                {
                    { 1, 1, "A" },
                    { 2, 1, "A" },
                    { 3, 1, "A" },
                    { 4, 1, "A" },
                    { 5, 1, "B" },
                    { 6, 1, "B" },
                    { 7, 1, "B" },
                    { 8, 1, "B" },
                    { 9, 1, "C" },
                    { 10, 1, "C" },
                    { 11, 1, "C" },
                    { 12, 1, "C" },
                    { 13, 1, "D" },
                    { 14, 1, "D" },
                    { 15, 1, "D" },
                    { 16, 1, "D" },
                    { 17, 1, "E" },
                    { 18, 1, "E" },
                    { 19, 1, "E" },
                    { 20, 1, "E" },
                    { 21, 1, "F" },
                    { 22, 1, "F" },
                    { 23, 1, "F" },
                    { 24, 1, "F" },
                    { 25, 1, "G" },
                    { 26, 1, "G" },
                    { 27, 1, "G" },
                    { 28, 1, "G" },
                    { 29, 1, "H" },
                    { 30, 1, "H" },
                    { 31, 1, "H" },
                    { 32, 1, "H" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorldCup_CountryId",
                table: "WorldCup",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldCupCountry_CountryId",
                table: "WorldCupCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldCupCountryPlayer_CountryId",
                table: "WorldCupCountryPlayer",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldCupCountryPlayer_PlayerId",
                table: "WorldCupCountryPlayer",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorldCupCountry");

            migrationBuilder.DropTable(
                name: "WorldCupCountryPlayer");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "WorldCup");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
