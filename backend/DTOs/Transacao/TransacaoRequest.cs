using System.ComponentModel.DataAnnotations;
using GestaoFinanceira.Api.Models;

namespace GestaoFinanceira.Api.DTOs.Transacao;

public class TransacaoRequest
{
    [Required]
    [StringLength(200)]
    public string Descricao { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Valor { get; set; }

    [Required]
    public TipoTransacao Tipo { get; set; }

    [Required]
    public Guid PessoaId { get; set; }
}