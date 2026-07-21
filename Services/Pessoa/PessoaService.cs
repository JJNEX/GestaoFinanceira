using GestaoFinanceira.Api.Data;
using GestaoFinanceira.Api.DTOs.Pessoa;
using GestaoFinanceira.Api.Models;
using GestaoFinanceira.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Api.Services;

public class PessoaService : IPessoaService
{
    private readonly AppDbContext _context;

    public PessoaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PessoaResponse>> ListarAsync()
    {
        return await _context.Pessoas
            .Select(p => new PessoaResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Idade = p.Idade
            })
            .ToListAsync();
    }

    public async Task<PessoaResponse> CriarAsync(PessoaRequest request)
    {
        var pessoa = new Pessoa
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Idade = request.Idade
        };

        _context.Pessoas.Add(pessoa);

        await _context.SaveChangesAsync();

        return ToResponse(pessoa);
    }

    public async Task<PessoaResponse?> BuscarPorIdAsync(Guid id)
{
    var pessoa = await _context.Pessoas.FindAsync(id);

    if (pessoa is null)
        return null;

    return ToResponse(pessoa);
}

    public async Task<bool> ExcluirAsync(Guid id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);

        if (pessoa is null)
            return false;

        _context.Pessoas.Remove(pessoa);

        await _context.SaveChangesAsync();

        return true;
    }

    private static PessoaResponse ToResponse(Pessoa pessoa)
    {
        return new PessoaResponse
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome,
            Idade = pessoa.Idade
        };
    }
}