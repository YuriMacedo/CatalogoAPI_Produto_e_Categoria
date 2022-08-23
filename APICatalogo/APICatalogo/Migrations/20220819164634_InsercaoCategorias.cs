using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class InsercaoCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into categorias(Nome, ImagemUrl) values('Bebidas','bebidas.jpg')");
            migrationBuilder.Sql("Insert into categorias(Nome, ImagemUrl) values('Lanches','lanches.jpg')");
            migrationBuilder.Sql("Insert into categorias(Nome, ImagemUrl) values('Sobremesas','sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
