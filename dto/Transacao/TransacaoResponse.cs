namespace GestaoFinanceira.Api.DTOs.Transacao;

using GestaoFinanceira.Api.Models;

public class TransacaoResponse
{
    public Guid Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    public Guid PessoaId { get; set; }

    public string NomePessoa { get; set; } = string.Empty;
}