using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_Project.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalisanKategorileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanKategorileri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    CalisanKategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calisanlar_CalisanKategorileri_CalisanKategoriId",
                        column: x => x.CalisanKategoriId,
                        principalTable: "CalisanKategorileri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CalisanKategorileri",
                columns: new[] { "Id", "Adi" },
                values: new object[,]
                {
                    { 1, "İnsan Kaynakları" },
                    { 2, "Üretim" },
                    { 3, "Tedarik Zinciri" },
                    { 4, "Müşteri İlişkileri" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_CalisanKategoriId",
                table: "Calisanlar",
                column: "CalisanKategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropTable(
                name: "CalisanKategorileri");
        }
    }
}
