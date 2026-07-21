namespace GestaoFinanceira.Api.DTOs.Pessoa;

public class PessoaResponse
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public int Idade { get; set; }
}