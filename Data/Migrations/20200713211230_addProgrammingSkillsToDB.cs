using Microsoft.EntityFrameworkCore.Migrations;

namespace BadrBinHomeed_NEW.Data.Migrations
{
    public partial class addProgrammingSkillsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programming_Skills_Ar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programming_Skills_Ar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programming_Skills_En",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programming_Skills_En", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programming_Skills_Ar");

            migrationBuilder.DropTable(
                name: "Programming_Skills_En");
        }
    }
}
