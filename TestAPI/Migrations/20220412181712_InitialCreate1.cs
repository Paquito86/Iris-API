using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPI.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    longId = table.Column<string>(type: "TEXT", nullable: true),
                    DatacenterId = table.Column<int>(type: "INTEGER", nullable: false),
                    CPU = table.Column<string>(type: "TEXT", nullable: true),
                    CPUCores = table.Column<int>(type: "INTEGER", nullable: false),
                    RAM = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    Provider = table.Column<string>(type: "TEXT", nullable: true),
                    Retired = table.Column<bool>(type: "INTEGER", nullable: false),
                    Pterodactyl = table.Column<bool>(type: "INTEGER", nullable: false),
                    Monolith = table.Column<bool>(type: "INTEGER", nullable: false),
                    Docker = table.Column<bool>(type: "INTEGER", nullable: false),
                    Kubernetes = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nodes");
        }
    }
}
