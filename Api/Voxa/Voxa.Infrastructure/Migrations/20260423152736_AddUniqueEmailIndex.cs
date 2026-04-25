using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voxa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueEmailIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "user",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_email",
                table: "user");

            migrationBuilder.DropColumn(
                name: "email",
                table: "user");

            migrationBuilder.DropColumn(
                name: "password",
                table: "user");
        }
    }
}
