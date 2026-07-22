using GestaoFinanceira.Api.DTOs.Total;
using GestaoFinanceira.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFinanceira.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TotaisController : ControllerBase
{
    private readonly ITotalService _totalService;

    public TotaisController(ITotalService totalService)
    {
        _totalService = totalService;
    }

    [HttpGet]
    public async Task<ActionResult<TotaisResponse>> Consultar()
    {
        TotaisResponse totais = await _totalService.ConsultarTotaisAsync();

        return Ok(totais);
    }
}