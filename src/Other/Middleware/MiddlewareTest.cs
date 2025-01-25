namespace testme2.MiddlewareDemo;

public class MiddlewareTest
{
    Dictionary<Type, object> dic = new();
    Builder builder = new Builder();

    [Fact]
    public void Test()
    {
        dic.Add(typeof(Middleware1), new Middleware1());
        dic.Add(typeof(Middleware2), new Middleware2());
        dic.Add(typeof(Middleware3), new Middleware3());

        Use(typeof(Middleware1));
        Use(typeof(Middleware2));
        Use(typeof(Middleware3));
        builder.Run();
    }

    void Use(Type type)
    {
        var binder = new InterfaceMiddlewareBinder(dic[type] as IMiddleware);
        var middleware = binder.CreateMiddleware;
        builder.Use(middleware);
    }

    private sealed class InterfaceMiddlewareBinder
    {
        private readonly IMiddleware _middlewareType;

        public InterfaceMiddlewareBinder(IMiddleware middlewareType)
        {
            _middlewareType = middlewareType;
        }

        public RequestDelegate CreateMiddleware(RequestDelegate next)
        {
            return async context => { await _middlewareType.InvokeAsync(context, next); };
        }
    }
}

public class Builder
{
    public List<Func<RequestDelegate, RequestDelegate>> _components = new();
    public List<string> _descriptions = new();

    public void Use(Func<RequestDelegate, RequestDelegate> middleware)
    {
        _components.Add(middleware);
        _descriptions?.Add(CreateMiddlewareDescription(middleware));
    }

    private string CreateMiddlewareDescription(Func<RequestDelegate, RequestDelegate> middleware)
    {
        return middleware.Method.Name;
    }

    public void Run()
    {
        var context = new MyConext();
        RequestDelegate next = async (c) => await Task.Run(() => Task.CompletedTask );
        // sequence used in aspnetcore
        for (var c = _components.Count - 1; c >= 0; c--)
        {
            next = _components[c](next);
        }

        next(context).GetAwaiter().GetResult();

        Assert.True("acefdb" == context.Prop);


        // Just for test I change call order
        context.Reset();
        //  reset too
        next = async (c) => await Task.Run(() => Task.CompletedTask);

        foreach (var middleware in _components)
        {
            next = middleware(next);
        }

        next(context).GetAwaiter().GetResult();

        Assert.True("ecabdf" == context.Prop);
    }
}