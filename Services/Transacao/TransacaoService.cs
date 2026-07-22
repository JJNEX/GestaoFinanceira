using GestaoFinanceira.Api.Data;
using GestaoFinanceira.Api.DTOs.Transacao;
using GestaoFinanceira.Api.Models;
using GestaoFinanceira.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Api.Services;

public class TransacaoService : ITransacaoService
{
    private readonly AppDbContext _context;

    public TransacaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TransacaoResponse>> ListarAsync()
    {
        return await _context.Transacoes
            .Select(t => new TransacaoResponse
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Valor = t.Valor,
                Tipo = t.Tipo,
                PessoaId = t.PessoaId,
                NomePessoa = t.Pessoa.Nome
            })
            .ToListAsync();
    }

    public async Task<TransacaoResponse> CriarAsync(TransacaoRequest request)
    {
        Pessoa? pessoa = await _context.Pessoas.FindAsync(request.PessoaId);

        if (pessoa is null)
            throw new ArgumentException("Pessoa não encontrada.");

        if (pessoa.Idade < 18 && request.Tipo == TipoTransacao.Receita)
        {
            throw new InvalidOperationException(
                "Menores de idade só podem cadastrar despesas.");
        }

        Transacao transacao = new()
        {
            Id = Guid.NewGuid(),
            Descricao = request.Descricao,
            Valor = request.Valor,
            Tipo = request.Tipo,
            PessoaId = pessoa.Id
        };

        _context.Transacoes.Add(transacao);

        await _context.SaveChangesAsync();

        transacao.Pessoa = pessoa;

        return ToResponse(transacao);

    }

    private static TransacaoResponse ToResponse(Transacao transacao)
    {
        return new TransacaoResponse
        {
            Id = transacao.Id,
            Descricao = transacao.Descricao,
            Valor = transacao.Valor,
            Tipo = transacao.Tipo,
            PessoaId = transacao.PessoaId,
            NomePessoa = transacao.Pessoa.Nome
        };
    }
}