using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaDisciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
        mb.Sql("INSERT INTO Disciplinas(Nome, CursoId) VALUES('Programação', 1)");
        mb.Sql("INSERT INTO Disciplinas(Nome, CursoId) VALUES('Estrutura De Dados', 1)");
        mb.Sql("INSERT INTO Disciplinas(Nome, CursoId) VALUES('Redes De Computadores', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
         /*----------------
         Em discussão
         --------------------*/
        }
    }
}
