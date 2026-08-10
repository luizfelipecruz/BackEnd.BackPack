
public class RequestContext<TRequest, TResponse>
{
    public TRequest Request { get; }
    public Func<Task<TResponse>> Next { get; }

    public RequestContext(TRequest request, Func<Task<TResponse>> next)
    {
        Request = request;
        Next = next;
    }
}

