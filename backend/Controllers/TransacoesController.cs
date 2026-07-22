using GestaoFinanceira.Api.DTOs.Transacao;
using GestaoFinanceira.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFinanceira.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacaoController : ControllerBase
{
    private readonly ITransacaoService _transacaoService;

    public TransacaoController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransacaoResponse>>> Listar()
    {
        IEnumerable<TransacaoResponse> transacoes =
            await _transacaoService.ListarAsync();

        return Ok(transacoes);
    }

    [HttpPost]
    public async Task<ActionResult<TransacaoResponse>> Criar(
        TransacaoRequest request)
    {
        try
        {
            TransacaoResponse transacao =
                await _transacaoService.CriarAsync(request);

            return Created(string.Empty, transacao);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}