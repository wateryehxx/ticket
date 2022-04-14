namespace DbContext.Ticket.Tables;

public class User
{
    public User()
    {
        IssueHistories = new HashSet<IssueHistory>();
        Issues = new HashSet<Issue>();
    }

    public Guid UserId { get; set; }
    public int RoleId { get; set; }
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
    public virtual ICollection<IssueHistory> IssueHistories { get; set; }
    public virtual ICollection<Issue> Issues { get; set; }
}