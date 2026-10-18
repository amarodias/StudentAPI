using System;
using StudentAPI.Models;

namespace StudentAPI.Services;

public interface IDisciplinaService
{
Task <IEnumerable<Disciplina>> ListarDisciplinaAsync();
Task <Disciplina?>  ObterPeloIdAsync (int id);
Task <Disciplina?> CriarAsync(Disciplina disciplina);
Task <Disciplina?> AtualizarAsync(int id, Disciplina disciplina);
Task <bool> DeletarAsync(int id); 
}
