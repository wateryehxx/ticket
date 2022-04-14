namespace DbContext.Ticket.Tables;

public class IssueHistory
{
    public Guid IssueHistoryId { get; set; }
    public Guid IssueId { get; set; }
    public Guid UserId { get; set; }
    public int IssueStatusId { get; set; }
    public DateTime CreateTime { get; set; }

    public virtual Issue Issue { get; set; } = null!;
    public virtual IssueStatus IssueStatus { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}