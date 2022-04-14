using Api.Models.TicketController;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class TicketController : ControllerBase
{
    /// <summary>
    ///     建立
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    [HttpPost("Create")]
    public async Task<OkResult> _([FromBody] CreateTicket _)
    {
        return Ok();
    }

    /// <summary>
    ///     查詢
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<IEnumerable<Ticket>> GetUsers()
    {
        return new List<Ticket>();
    }
}