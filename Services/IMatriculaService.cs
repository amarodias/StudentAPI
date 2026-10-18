using System;
using StudentAPI.Models;

namespace StudentAPI.Services;

public interface IMatriculaService

{
    Task <IEnumerable<Matricula?>> ListarMatriculasAsync();
    Task <Matricula?> ObterPeloIdAsync(int id);
    Task <Matricula?> CriarAsync(Matricula matricula);
    Task <Matricula?> AtualizarAsync (int id, Matricula matricula);
    Task <bool> DeletarAsync(int id);
}
