namespace testme2.MiddlewareDemo;

public class MyConext
{
    public string Prop { get; set; } = "";

    public void Reset()
    {
        Prop = "";
    }
}

public delegate Task RequestDelegate(MyConext context);

public interface IMiddleware
{
    Task InvokeAsync(MyConext context, RequestDelegate next);
}

public class Middleware1 : IMiddleware
{
    public async Task InvokeAsync(MyConext context, RequestDelegate next)
    {
        context.Prop += "a";
        await next(context);
       // this one is called  last in the queue so  it has  priority to overwrite the context
       context.Prop += "b"; 
    }
}

public class Middleware2 : IMiddleware
{
    public async Task InvokeAsync(MyConext context, RequestDelegate next)
    {
        context.Prop += "c";
        await next(context);
        context.Prop += "d";
    }
}

public class Middleware3 : IMiddleware
{
    public async Task InvokeAsync(MyConext context, RequestDelegate next)
    {
        context.Prop += "e";
        await next(context);
        context.Prop += "f";
    }
}