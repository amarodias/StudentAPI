using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaEstudante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
        mb.Sql("INSERT INTO Estudantes (Nome, Email, Telefone, CursoId) values('Amaro Dias', '20260001student.co.ao', '932951841', 1)");
        mb.Sql("INSERT INTO Estudantes (Nome, Email, Telefone, CursoId) values('Weza Vemba', '20260002student.co.ao', '937525793', 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {

        }
    }
}
