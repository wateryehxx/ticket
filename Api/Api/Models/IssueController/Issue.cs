using System.ComponentModel.DataAnnotations;

namespace Api.Models.IssueController;

public class Issue
{
    [Required] public Guid IssueId { get; set; }
    [Required] public Guid UserId { get; set; }
    [Required] public int IssueStatusId { get; set; }
    [Required] public string Title { get; set; } = null!;
    [Required] public string Summary { get; set; } = null!;
    [Required] public virtual List<IssueHistory> IssueHistories { get; set; }
}