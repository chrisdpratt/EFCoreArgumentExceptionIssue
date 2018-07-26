using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreArgumentExceptionIssue.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Foos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Foo 1" });

            migrationBuilder.InsertData(
                table: "Foos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Foo 2" });

            migrationBuilder.InsertData(
                table: "Foos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3L, "Foo 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foos");
        }
    }
}
