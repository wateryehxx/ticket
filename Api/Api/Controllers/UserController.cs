using Api.Models.UserController;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class UserController : ControllerBase
{
    /// <summary>
    ///     登出
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    [HttpPost(nameof(Logout))]
    public async Task<OkResult> _([FromBody] Logout _)
    {
        return Ok();
    }

    /// <summary>
    ///     登入
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    [HttpPost(nameof(Login))]
    public async Task<OkResult> _([FromBody] Login _)
    {
        return Ok();
    }

    /// <summary>
    ///     建立
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    [HttpPost("Create")]
    public async Task<OkResult> _([FromBody] CreateUser _)
    {
        return Ok();
    }

    /// <summary>
    ///     查詢
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return new List<User>();
    }
}