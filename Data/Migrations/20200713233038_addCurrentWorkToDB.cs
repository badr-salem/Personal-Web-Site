using Microsoft.EntityFrameworkCore.Migrations;

namespace BadrBinHomeed_NEW.Data.Migrations
{
    public partial class addCurrentWorkToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Current_Work_Ar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Current_Work_Ar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Current_Work_En",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Current_Work_En", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Current_Work_Ar");

            migrationBuilder.DropTable(
                name: "Current_Work_En");
        }
    }
}
