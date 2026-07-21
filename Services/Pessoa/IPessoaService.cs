using GestaoFinanceira.Api.DTOs.Pessoa;

namespace GestaoFinanceira.Api.Services.Interfaces;

public interface IPessoaService
{
    Task<IEnumerable<PessoaResponse>> ListarAsync();

    Task<PessoaResponse> CriarAsync(PessoaRequest request);

    Task<bool> ExcluirAsync(Guid id);

    Task<PessoaResponse?> BuscarPorIdAsync(Guid id);
}