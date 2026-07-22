namespace GestaoFinanceira.Api.DTOs.Total;

public class TotaisResponse
{
    public IEnumerable<TotalPessoaResponse> Pessoas { get; set; }
        = [];

    public decimal TotalReceitas { get; set; }

    public decimal TotalDespesas { get; set; }

    public decimal SaldoLiquido { get; set; }
}