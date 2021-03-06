using Api.Infrastructures;
using Api.Models.UserController;
using DbContext.Ticket;
using Domain;
using Domain.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class UserController : ControllerBase
{
    private readonly TicketContext _db;
    private readonly IJwtAuth _jwtAuth;
    private readonly IUserRepository _userRepository;

    public UserController(IJwtAuth jwtAuth, TicketContext db,
        IUserRepository userRepository)
    {
        _jwtAuth = jwtAuth;
        _db = db;
        _userRepository = userRepository;
    }

    /// <summary>
    ///     登入
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost(nameof(Login))]
    public async Task<LoginResponse> _([FromBody] Login dto)
    {
        var user = await _userRepository.Login(dto);
        return new LoginResponse
        {
            JwtAuth = _jwtAuth.Encrypt(user)
        };
    }

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
    ///     建立
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("Create")]
    [TypeFilter(typeof(Authorize), Arguments = new object[] {Role.Admin})]
    public async Task<OkResult> _([FromBody] CreateUser dto)
    {
        await _userRepository.Create(dto);
        await _db.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    ///     更新
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    [TypeFilter(typeof(Authorize), Arguments = new object[] {Role.Admin})]
    public async Task<OkResult> _([FromBody] UpdateUser dto)
    {
        await _userRepository.Update(dto);
        await _db.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    ///     刪除
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    [TypeFilter(typeof(Authorize), Arguments = new object[] {Role.Admin})]
    public async Task<OkResult> _(Guid userId)
    {
        _userRepository.Delete(userId);
        await _db.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    ///     查詢
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<List<User>> GetUsers()
    {
        var users = await _userRepository.GetAll();
        return users.Select(u => new User
        {
            UserId = u.UserId,
            RoleId = u.RoleId,
            Name = u.Name
        }).ToList();
    }
}