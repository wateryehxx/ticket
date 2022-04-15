using System.Security.Authentication;
using Domain;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Infrastructures;

public class Authorize : ActionFilterAttribute
{
    private readonly IJwtAuth _jwtAuth;
    private readonly Role _roles;

    public Authorize(Role roles, IJwtAuth jwtAuth)
    {
        _roles = roles;
        _jwtAuth = jwtAuth;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (_jwtAuth.UserId != Guid.Empty) throw new AuthenticationException();

        var role = (Role) _jwtAuth.RoleId;
        if ((_roles & role) != role)
            throw new AuthenticationException();

        await next();
    }
}