using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAPI.Models;

public class Curso
{
[Key]

public int Id { get; set; }

[Required]
[StringLength(80)]
public string? Nome { get; set; }

[Required]
[StringLength(80)]
public string? Descricao { get; set; }

}
