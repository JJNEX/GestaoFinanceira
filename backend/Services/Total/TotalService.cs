using GestaoFinanceira.Api.Data;
using GestaoFinanceira.Api.DTOs.Total;
using GestaoFinanceira.Api.Models;
using GestaoFinanceira.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Api.Services;

public class TotalService : ITotalService
{
    private readonly AppDbContext _context;

    public TotalService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TotaisResponse> ConsultarTotaisAsync()
    {

        List<Pessoa> pessoas = await _context.Pessoas
    .Include(p => p.Transacoes)
    .ToListAsync();


        List<TotalPessoaResponse> totaisPorPessoa = new();

        foreach (Pessoa pessoa in pessoas)
        {
            decimal receitas = pessoa.Transacoes
    .Where(t => t.Tipo == TipoTransacao.Receita)
    .Sum(t => t.Valor);

            decimal despesas = pessoa.Transacoes
            .Where(t => t.Tipo == TipoTransacao.Despesa)
            .Sum(t => t.Valor);

            decimal saldo = receitas - despesas;

            TotalPessoaResponse totalPessoa = new()
            {
                PessoaId = pessoa.Id,
                Nome = pessoa.Nome,
                Receitas = receitas,
                Despesas = despesas,
                Saldo = saldo
            };

            totaisPorPessoa.Add(totalPessoa);

        }

        decimal totalReceitas = totaisPorPessoa.Sum(t => t.Receitas);

        decimal totalDespesas = totaisPorPessoa.Sum(t => t.Despesas);

        decimal saldoLiquido = totalReceitas - totalDespesas;

        TotaisResponse resposta = new()
        {
            Pessoas = totaisPorPessoa,
            TotalReceitas = totalReceitas,
            TotalDespesas = totalDespesas,
            SaldoLiquido = saldoLiquido
        };

        return resposta;

    }
}