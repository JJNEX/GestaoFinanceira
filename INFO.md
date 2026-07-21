# Projeto: GestaoFinanceira

## Status:
[X] API criada
[X] Controllers configurados
[X] Swagger adicionado
[X] Entidades criadas
[X] Endpoints implementados(Parcialmente)
[ ] React criado

Classes: Pessoa, Transacao
Banco: gestao_financeira_db
Tabelas: pessoas, transacoes


# Resumo do Projeto
## Objetivo

### Desenvolver um sistema de controle de gastos residenciais.

## Tecnologias
Back-end: .NET com C#
Front-end: React + TypeScript
Banco de dados: PostgreSQL

## Estrutura do projeto

Projeto criado [X]

## API

A API já está funcionando.

Foi testado

Também criei um TesteController para validar o funcionamento dos Controllers(Não existe mais).


Modelagem prevista(pode sofrer modificações)

Pessoa
Campos:

Id
Nome
Idade
Transacao

Transacao
Campos:

Id
Descricao
Valor
Tipo
PessoaId
Pessoa

Relacionamento:

Pessoa
   │
   │ 1
   │
   N
Transacao


# Regras de negócio

## Implementar:

Cadastro de Pessoas
Criar
Listar
Excluir

## Ao excluir uma pessoa:

remover todas as transações dela.
Cadastro de Transações
Criar
Listar

Não será necessário editar nem excluir.

## Menor de idade

Se:

Idade < 18

somente poderá cadastrar:

Despesa

Receita deverá ser rejeitada pela API.

## Consulta de totais

Retornar para cada pessoa:

Receitas
Despesas
Saldo

e ao final:

Total Geral
Receitas
Despesas
Saldo Líquido


# Criar:

AppDbContext

## Models

### Criar:

Pessoa
Transacao

## Migrations

Criar a primeira migration.

## Controllers

### Criar:

PessoasController
TransacoesController
TotaisController

# React

Depois da API pronta:

React
TypeScript
Axios
CRUD
Tela de Totais

# Decisões tomadas


✔ Utilizar PostgreSQL.

✔ Estrutura simples e organizada.

✔ Banco chamado:

gestao_financeira_db

✔ Swagger será utilizado para testar a API, embora não seja um requisito do desafio.

# Futuro do desenvolvimento

## Planejamento

Criar o banco gestao_financeira_db. ✔
Configurar o Entity Framework Core. ✔
Criar as entidades Pessoa e Transacao. ✔
Gerar as migrations. ✔
Implementar os controllers e as regras de negócio. (Parcial)
Desenvolver o front-end em React.
Revisar o código, adicionar comentários onde fizer sentido e preparar o repositório para entrega.

