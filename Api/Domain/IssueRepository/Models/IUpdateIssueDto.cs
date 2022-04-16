namespace Domain.IssueRepository.Models;

public interface IUpdateIssueDto
{
    public Guid IssueId { get; set; }
    public Guid UserId { get; set; }
    public int IssueStatusId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
}