namespace Domain.IssueRepository.Models;

public interface ICreateIssueDto
{
    public Guid UserId { get; set; }
    public int IssueStatusId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
}