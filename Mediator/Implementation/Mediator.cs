using MediatR.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR.Implementation;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse))
            ?? throw new InvalidOperationException($"Tipo de manipulador não implementado");

        var handler = _serviceProvider.GetService(handlerType)
            ?? throw new InvalidOperationException($"Tipo de manipulador não encontrado para {request.GetType().Name}");

        var behaviors = _serviceProvider
            .GetServices<IPipelineBehavior<IRequest<TResponse>, TResponse>>()
            .Reverse()
            .ToList();

        var method = handlerType.GetMethod("Handle")
            ?? throw new InvalidOperationException("Método do manipulador não encontrado.");

        Func<Task<TResponse>> task = () =>
        {
            var result = method.Invoke(handler, new object[] { request, cancellationToken });

            if (result is not Task<TResponse> typedResult)
                throw new InvalidOperationException("Manipulador não retornou o tipo correto Task<TResponse>");

            return typedResult;
        };

        foreach (var behavior in behaviors)
        {
            var currentTask = task;
            task = () => behavior.Handle(request, currentTask, cancellationToken);
        }

        return await task();
    }
}
