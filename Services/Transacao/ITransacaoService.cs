using GestaoFinanceira.Api.DTOs.Transacao;

namespace GestaoFinanceira.Api.Services.Interfaces;

public interface ITransacaoService
{
    Task<IEnumerable<TransacaoResponse>> ListarAsync();

    Task<TransacaoResponse> CriarAsync(TransacaoRequest request);
}