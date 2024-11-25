    using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppQLKH.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "De_Tai",
                columns: table => new
                {
                    MaDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KinhPhi = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_De_Tai", x => x.MaDT);
                });

            migrationBuilder.CreateTable(
                name: "Giang_Vien",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giang_Vien", x => x.MaGV);
                });

            migrationBuilder.CreateTable(
                name: "Tham_Gia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaGV = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaDT = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SoGio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tham_Gia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tham_Gia_De_Tai_MaDT",
                        column: x => x.MaDT,
                        principalTable: "De_Tai",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_Tham_Gia_Giang_Vien_MaGV",
                        column: x => x.MaGV,
                        principalTable: "Giang_Vien",
                        principalColumn: "MaGV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tham_Gia_MaDT",
                table: "Tham_Gia",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_Tham_Gia_MaGV",
                table: "Tham_Gia",
                column: "MaGV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tham_Gia");

            migrationBuilder.DropTable(
                name: "De_Tai");

            migrationBuilder.DropTable(
                name: "Giang_Vien");
        }
    }
}
