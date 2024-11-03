using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class media : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Media",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_ServiceId",
                table: "Media",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Service_ServiceId",
                table: "Media",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Service_ServiceId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_ServiceId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Media");
        }
    }
}
