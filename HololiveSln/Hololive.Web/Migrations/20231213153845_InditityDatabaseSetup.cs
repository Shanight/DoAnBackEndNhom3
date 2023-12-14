using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hololive.Web.Migrations
{
    /// <inheritdoc />
    public partial class InditityDatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(255)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Role = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
