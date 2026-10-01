using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaMatricula : Migration
    {
        /// <inheritdoc />
        ///
        /*
        public bool? Estado { get; set; }
[ForeignKey("Id")]
public int EstudanteId { get; set; } 
public Estudante? Estudante { get; set; }
 public int DisciplinaId { get; set; } 
 public Disciplina? Discipline { get; set; }
        
        */
        protected override void Up(MigrationBuilder mb)
        {
        mb.Sql("Insert into Matriculas (Estado, EstudanteId, DisciplinaId) values (true, 1, 1)");
        mb.Sql("Insert into Matriculas (Estado, EstudanteId, DisciplinaId) values (true, 1, 2)");
        mb.Sql("Insert into Matriculas (Estado, EstudanteId, DisciplinaId) values (true, 1, 3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
