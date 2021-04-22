using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kassYazilim.Migrations
{
    public partial class d1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "odev",
                columns: table => new
                {
                    OdevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odev", x => x.OdevId);
                });

            migrationBuilder.CreateTable(
                name: "ogrenci",
                columns: table => new
                {
                    OgrenciId = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LastName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    OdevId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ogrenci", x => x.OgrenciId);
                    table.ForeignKey(
                        name: "FK_ogrenci_odev_OdevId",
                        column: x => x.OdevId,
                        principalTable: "odev",
                        principalColumn: "OdevId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ogrenci_OdevId",
                table: "ogrenci",
                column: "OdevId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ogrenci");

            migrationBuilder.DropTable(
                name: "odev");
        }
    }
}
