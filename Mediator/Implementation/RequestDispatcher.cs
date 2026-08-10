//using MediatR.Interfaces;
//using Microsoft.Extensions.DependencyInjection;

namespace MediatR.Implementation;

public class RequestDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public RequestDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    //public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
    //    where TRequest : IRequest<TResponse>
    //{
    //    var handler = _serviceProvider
    //        .GetRequiredService<IRequestHandler<TRequest, TResponse>>();

    //    var behaviors = _serviceProvider
    //        .GetServices<IPipelineBehavior<TRequest, TResponse>>()
    //        .Reverse()
    //        .ToList();

    //    Func<Task<TResponse>> next = () => handler.Handle(request);

    //    foreach (var behavior in behaviors)
    //    {
    //        var currentNext = next;
    //        next = () => behavior.Handle(request, currentNext, cancellationToken);
    //    }

    //    return await next();
    //}
}
