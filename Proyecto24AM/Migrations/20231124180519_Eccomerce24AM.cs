using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto24AM.Migrations
{
    /// <inheritdoc />
    public partial class Eccomerce24AM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    PKArticle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.PKArticle);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    PKBook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.PKBook);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    PKRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.PKRol);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    PKUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.PKUser);
                    table.ForeignKey(
                        name: "FK_Users_Rols_FKRol",
                        column: x => x.FKRol,
                        principalTable: "Rols",
                        principalColumn: "PKRol");
                });

            migrationBuilder.InsertData(
                table: "Rols",
                columns: new[] { "PKRol", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "sa" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "PKUser", "FKRol", "Name", "Password", "UserName", "lastName" },
                values: new object[,]
                {
                    { 1, 1, "David", "1234", "davi120", "Peña" },
                    { 2, 2, "Diego", "1234", "dieguitocraft", "Cortez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FKRol",
                table: "Users",
                column: "FKRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rols");
        }
    }
}
