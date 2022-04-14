using Api.Models.IssueController;
using DbContext.Ticket;
using Domain.IssueRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class IssueController : ControllerBase
{
    private readonly TicketContext _db;
    private readonly IIssueRepository _issueRepository;

    public IssueController(TicketContext db, IIssueRepository issueRepository)
    {
        _db = db;
        _issueRepository = issueRepository;
    }

    /// <summary>
    ///     刪除
    /// </summary>
    /// <param name="issueId"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public async Task<OkResult> _(Guid issueId)
    {
        _issueRepository.Delete(issueId);
        await _db.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    ///     建立
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("Create")]
    public async Task<OkResult> _([FromBody] CreateIssue dto)
    {
        await _issueRepository.Create(dto);
        await _db.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    ///     更新
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<OkResult> _([FromBody] UpdateIssue dto)
    {
        await _issueRepository.Update(dto);
        await _db.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    ///     查詢
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<List<Issue>> GetUsers()
    {
        var issues = await _issueRepository.GetAll();
        return issues.Select(i => new Issue
        {
            IssueId = i.IssueId,
            UserId = i.UserId,
            Title = i.Title,
            Summary = i.Summary
        }).ToList();
    }
}