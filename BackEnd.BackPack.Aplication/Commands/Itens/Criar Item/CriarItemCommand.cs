using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Extensions;
using BackEnd.BackPack.Domain.Repositories;
using MediatR.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;

namespace BackEnd.BackPack.Aplication.Commands.Itens.Criar_Item;

public record CriarItemCommand(CriarItemCommandRequest Request) : IRequest<Result<CriarItemCommandResponse>>;
public class CriarItemComandHandler(IItensRepository itensRepository) : IRequestHandler<CriarItemCommand, Result<CriarItemCommandResponse>>
{
    public Task<Result<CriarItemCommandResponse>> Handle(CriarItemCommand request, CancellationToken cancellationToken = default)
    {

        throw new NotImplementedException();
    }
}
