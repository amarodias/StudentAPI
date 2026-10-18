using System;
using StudentAPI.Models;

namespace StudentAPI.Services;

public interface ICursoService
{
Task <IEnumerable<Curso>> ListarCursosAsync();
Task <Curso?> ObterCursoPeloIdAsync(int id);
Task <Curso?> CriarAsync(Curso curso);
Task <Curso?> AtualizarAsync(int id, Curso curso);
Task <bool> EliminarAsync(int id);
}
