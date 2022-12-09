using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorContactos.Server.Migrations
{
    public partial class relacion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediosContactoId",
                table: "Contactos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediosContactoId",
                table: "Contactos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
