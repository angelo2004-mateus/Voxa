using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voxa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablesConvetionName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Organizations_OrganizationId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Users_UserId",
                table: "Memberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "organization");

            migrationBuilder.RenameTable(
                name: "Memberships",
                newName: "organizationmembership");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "user",
                newName: "updatedtime");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "user",
                newName: "creationtime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "organization",
                newName: "updatedtime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "organization",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "organization",
                newName: "creationtime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "organization",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "organizationmembership",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "organizationmembership",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "organizationmembership",
                newName: "organizationid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "organizationmembership",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_UserId_OrganizationId",
                table: "organizationmembership",
                newName: "IX_organizationmembership_userid_organizationid");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_OrganizationId",
                table: "organizationmembership",
                newName: "IX_organizationmembership_organizationid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_organization",
                table: "organization",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_organizationmembership",
                table: "organizationmembership",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_organizationmembership_organization_organizationid",
                table: "organizationmembership",
                column: "organizationid",
                principalTable: "organization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_organizationmembership_user_userid",
                table: "organizationmembership",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_organizationmembership_organization_organizationid",
                table: "organizationmembership");

            migrationBuilder.DropForeignKey(
                name: "FK_organizationmembership_user_userid",
                table: "organizationmembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_organizationmembership",
                table: "organizationmembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_organization",
                table: "organization");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "organizationmembership",
                newName: "Memberships");

            migrationBuilder.RenameTable(
                name: "organization",
                newName: "Organizations");

            migrationBuilder.RenameColumn(
                name: "updatedtime",
                table: "Users",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "creationtime",
                table: "Users",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Memberships",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Memberships",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "organizationid",
                table: "Memberships",
                newName: "OrganizationId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Memberships",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_organizationmembership_userid_organizationid",
                table: "Memberships",
                newName: "IX_Memberships_UserId_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_organizationmembership_organizationid",
                table: "Memberships",
                newName: "IX_Memberships_OrganizationId");

            migrationBuilder.RenameColumn(
                name: "updatedtime",
                table: "Organizations",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Organizations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "creationtime",
                table: "Organizations",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Organizations",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Organizations_OrganizationId",
                table: "Memberships",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Users_UserId",
                table: "Memberships",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
