using System.ComponentModel.DataAnnotations;
using Domain.IssueRepository;

namespace Api.Models.IssueController;

public class UpdateIssue : IUpdateIssueDto
{
    [Required] public Guid IssueId { get; set; }
    [Required] public Guid UserId { get; set; }
    [Required] public int IssueStatusId { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Summary { get; set; }
}