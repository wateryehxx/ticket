using Api.Infrastructures;

namespace Api.Middlewares;

public class Authenticate
{
    private readonly RequestDelegate _next;

    public Authenticate(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IJwtAuth jwtAuth)
    {
        var bearer = context.Request.Headers["Authorization"].SingleOrDefault();
        if (!string.IsNullOrWhiteSpace(bearer)) jwtAuth.Decode(bearer);
        await _next(context);
    }
}