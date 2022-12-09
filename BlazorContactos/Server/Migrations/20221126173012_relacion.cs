using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorContactos.Server.Migrations
{
    public partial class relacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactoId",
                table: "MediosContactos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediosContactoId",
                table: "Contactos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MediosContactos_ContactoId",
                table: "MediosContactos",
                column: "ContactoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediosContactos_Contactos_ContactoId",
                table: "MediosContactos",
                column: "ContactoId",
                principalTable: "Contactos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediosContactos_Contactos_ContactoId",
                table: "MediosContactos");

            migrationBuilder.DropIndex(
                name: "IX_MediosContactos_ContactoId",
                table: "MediosContactos");

            migrationBuilder.DropColumn(
                name: "ContactoId",
                table: "MediosContactos");

            migrationBuilder.DropColumn(
                name: "MediosContactoId",
                table: "Contactos");
        }
    }
}
