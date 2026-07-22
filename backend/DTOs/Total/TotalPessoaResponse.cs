namespace GestaoFinanceira.Api.DTOs.Total;

public class TotalPessoaResponse
{
    public Guid PessoaId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public decimal Receitas { get; set; }

    public decimal Despesas { get; set; }

    public decimal Saldo { get; set; }
}