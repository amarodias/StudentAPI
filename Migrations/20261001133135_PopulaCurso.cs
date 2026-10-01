using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
         mb.Sql("INSERT INTO Cursos(Nome, Descricao) VALUES('Engenharia Informática','Departamento de Tecnologias e Geociências')");
         mb.Sql("INSERT INTO Cursos(Nome, Descricao) Values('Engenharia De Construção Civil', 'Departamento de Tecnologias e Geociências')"); 
         mb.Sql("INSERT INTO Cursos(Nome, Descricao) Values('Contabilidade', 'Departamento de Ciências Sociais Aplicadas')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
        /*
        Não será feita a remoção dos dados inseridos na tabela Cursos.
        Serão apenas adicionados novos se necesário.
        */
        }
    }
}
