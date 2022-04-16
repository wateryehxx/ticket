using DbContext.Ticket.Tables;
using Domain.IssueRepository.Models;

namespace Domain.IssueRepository;

public interface IIssueRepository
{
    ValueTask Create(ICreateIssueDto dto);
    void Delete(Guid issueId);
    ValueTask<Issue> Get(Guid issueId);
    ValueTask<List<Issue>> GetAll();
    ValueTask Update(IUpdateIssueDto dto);
}