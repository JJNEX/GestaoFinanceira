using System.ComponentModel.DataAnnotations;

namespace GestaoFinanceira.Api.DTOs.Pessoa;

public class PessoaRequest
{
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Range(0, 120)]
    public int Idade { get; set; }
}