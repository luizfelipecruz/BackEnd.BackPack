namespace MediatR.Interfaces;

public delegate Task<TResponse> RequestHandlerDelegate<TResponse>(CancellationToken t = default);

public interface IPipelineBehavior<in TRequest, TResponse> where TRequest : notnull
{
    Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next, CancellationToken cancellationToken = default);
}
