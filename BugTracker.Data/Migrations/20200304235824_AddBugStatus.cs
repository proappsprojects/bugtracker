using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Data.Migrations
{
    public partial class AddBugStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "Bugs",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1L, "Open" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2L, "Close" });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_StatusId",
                table: "Bugs",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Status_StatusId",
                table: "Bugs",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Status_StatusId",
                table: "Bugs");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_StatusId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Bugs");
        }
    }
}
