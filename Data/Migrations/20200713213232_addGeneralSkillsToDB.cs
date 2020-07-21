using Microsoft.EntityFrameworkCore.Migrations;

namespace BadrBinHomeed_NEW.Data.Migrations
{
    public partial class addGeneralSkillsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "General_Skills_Ar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General_Skills_Ar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "General_Skills_En",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General_Skills_En", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "General_Skills_Ar");

            migrationBuilder.DropTable(
                name: "General_Skills_En");
        }
    }
}
