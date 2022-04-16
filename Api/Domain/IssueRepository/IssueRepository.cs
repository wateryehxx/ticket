using DbContext.Ticket;
using DbContext.Ticket.Tables;
using Domain.IssueRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.IssueRepository;

public class IssueRepositoryRepository : IIssueRepository
{
    private readonly TicketContext _db;

    public IssueRepositoryRepository(TicketContext db)
    {
        _db = db;
    }

    public async ValueTask Create(ICreateIssueDto dto)
    {
        var issue = new Issue
        {
            IssueId = Guid.NewGuid(),
            UserId = dto.UserId,
            Title = dto.Title,
            Summary = dto.Summary,
            IssueStatusId = dto.IssueStatusId,
            IssueHistories = new List<IssueHistory>
            {
                new()
                {
                    IssueHistoryId = Guid.NewGuid(),
                    UserId = dto.UserId,
                    IssueStatusId = dto.IssueStatusId,
                    CreateTime = DateTime.UtcNow
                }
            }
        };

        await _db.AddAsync(issue);
    }

    public async ValueTask Update(IUpdateIssueDto dto)
    {
        var issue = _db.Issues.Single(i => i.IssueId == dto.IssueId);
        issue.Title = dto.Title;
        issue.Summary = dto.Summary;
        issue.IssueStatusId = dto.IssueStatusId;

        var issueHistory = new IssueHistory
        {
            IssueHistoryId = Guid.NewGuid(),
            IssueId = issue.IssueId,
            UserId = dto.UserId,
            IssueStatusId = dto.IssueStatusId,
            CreateTime = DateTime.UtcNow
        };

        await _db.AddAsync(issueHistory);
    }

    public void Delete(Guid issueId)
    {
        var issue = _db.Issues.Single(i => i.IssueId == issueId);
        _db.Issues.Remove(issue);
    }

    public async ValueTask<List<Issue>> GetAll()
    {
        return await _db.Issues.ToListAsync();
    }

    public async ValueTask<Issue> Get(Guid issueId)
    {
        return await _db.Issues.Include(i => i.IssueHistories)
            .SingleAsync(i => i.IssueId == issueId);
    }
}