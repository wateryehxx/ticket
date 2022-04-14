namespace DbContext.Ticket.Tables;

public class Role
{
    public Role()
    {
        Users = new HashSet<User>();
    }

    public int RoleId { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; }
}