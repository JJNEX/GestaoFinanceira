using GestaoFinanceira.Api.DTOs.Transacao;

namespace GestaoFinanceira.Api.Services;

public interface ITransacaoService
{
    Task<IEnumerable<TransacaoResponse>> ListarAsync();

    Task<TransacaoResponse> CriarAsync(TransacaoRequest request);
}