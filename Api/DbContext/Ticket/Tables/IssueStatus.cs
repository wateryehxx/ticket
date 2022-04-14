namespace DbContext.Ticket.Tables;

public class IssueStatus
{
    public IssueStatus()
    {
        IssueHistories = new HashSet<IssueHistory>();
        Issues = new HashSet<Issue>();
    }

    public int IssueStatusId { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<IssueHistory> IssueHistories { get; set; }
    public virtual ICollection<Issue> Issues { get; set; }
}