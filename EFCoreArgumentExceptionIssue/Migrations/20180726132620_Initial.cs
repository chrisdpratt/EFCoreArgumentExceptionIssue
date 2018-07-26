using System;
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
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foos");
        }
    }
}
