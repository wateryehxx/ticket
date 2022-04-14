using System.ComponentModel.DataAnnotations;

namespace Api.Models.IssueController;

public class IssueHistory
{
    [Required] public Guid UserId { get; set; }
    [Required] public string UserName { get; set; }
    [Required] public int IssueStatusId { get; set; }
    [Required] public DateTime CreateTime { get; set; }
}