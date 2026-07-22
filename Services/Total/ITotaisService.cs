using GestaoFinanceira.Api.DTOs.Total;

namespace GestaoFinanceira.Api.Services;

public interface ITotalService
{
    Task<TotaisResponse> ConsultarTotaisAsync();
}