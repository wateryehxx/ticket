using System.ComponentModel.DataAnnotations;
using Domain.IssueRepository.Models;

namespace Api.Models.IssueController;

public class CreateIssue : ICreateIssueDto
{
    [Required] public Guid UserId { get; set; }
    [Required] public int IssueStatusId { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Summary { get; set; }
}