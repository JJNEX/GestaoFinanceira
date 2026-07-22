using GestaoFinanceira.Api.DTOs.Pessoa;
using GestaoFinanceira.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFinanceira.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PessoaResponse>>> Listar()
    {
        var pessoas = await _pessoaService.ListarAsync();

        return Ok(pessoas);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PessoaResponse>> BuscarPorId(Guid id)
    {
        var pessoa = await _pessoaService.BuscarPorIdAsync(id);

        if (pessoa is null)
            return NotFound();

        return Ok(pessoa);
    }

    [HttpPost]
    public async Task<ActionResult<PessoaResponse>> Criar(PessoaRequest request)
    {
        var pessoa = await _pessoaService.CriarAsync(request);

        return CreatedAtAction(nameof(BuscarPorId), new { id = pessoa.Id }, pessoa);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Excluir(Guid id)
    {
        var excluida = await _pessoaService.ExcluirAsync(id);

        if (!excluida)
            return NotFound();

        return NoContent();
    }
}