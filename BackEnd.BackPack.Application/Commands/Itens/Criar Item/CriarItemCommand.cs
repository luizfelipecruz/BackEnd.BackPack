using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BackEnd.BackPack.Application.Commands.Itens.Criar_Item;

public record CriarItemCommand(CriarItemCommandRequest Request) : IRequest<Result<CriarItemCommandResponse>>;
//Request é o que o seu comando precisa de informação para poder executar.
//Response é o que o seu comando vai retornar para o usuário.
public class CriarItemComandHandler(IItensRepository ItensRepository, IUnitOfWork UnitOfWork) : IRequestHandler<CriarItemCommand, Result<CriarItemCommandResponse>>
//Handler é a classe que vai executar o comando, ela recebe o comando e retorna o resultado.
//Repository é a classe que vai acessar o banco de dados, ela é injetada no handler para que ele possa acessar os dados.
{
    public async Task<Result<CriarItemCommandResponse>> Handle(CriarItemCommand body, CancellationToken cancellationToken = default)
    {
        var item = new Item
        {
            Nome = body.Request.Nome,
            Descricao = body.Request.Descricao,
            Peso = body.Request.Peso,
            Durabilidade = body.Request.Durabilidade,
            Tamanho = body.Request.Tamanho,
            Dureza = body.Request.Dureza,
            Raridade = body.Request.Raridade,
            Tipo = body.Request.Tipo,

        };

        await ItensRepository.AddAsync(item); 
        await UnitOfWork.SaveChangesAsync();
        //Await é a forma do sistema esperar a execução de uma tarefa assíncrona, sem bloquea
        //a thread principal.
        return Result<CriarItemCommandResponse>.Success(new CriarItemCommandResponse(item){ },"Item criado com sucesso");
    }
}
