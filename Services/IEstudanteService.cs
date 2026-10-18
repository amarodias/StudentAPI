using System;
using StudentAPI.Models;

namespace StudentAPI.Services;

public interface IEstudanteService
{
    Task <IEnumerable<Estudante>> ListarTodosAsync();
    Task <Estudante?> BuscarPorIdAsync(int id);
    Task <Estudante?> CriarAsync(Estudante estudante);
    Task <Estudante?> AtualizarAsync(int id, Estudante estudante);
    Task <bool> EliminarAsync(int id);

}
