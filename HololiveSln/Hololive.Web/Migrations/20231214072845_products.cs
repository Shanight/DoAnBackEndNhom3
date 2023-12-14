using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hololive.Web.Migrations
{
    /// <inheritdoc />
    public partial class products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Catetory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preview1 = table.Column<string>(type: "text", nullable: false),
                    Preview2 = table.Column<string>(type: "text", nullable: false),
                    Preview3 = table.Column<string>(type: "text", nullable: false),
                    Preview4 = table.Column<string>(type: "text", nullable: false),
                    Preview5 = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
