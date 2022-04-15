using DbContext.Ticket.Tables;

namespace Api.Infrastructures;

public interface IJwtAuth
{
    Guid UserId { get; set; }
    int RoleId { get; set; }
    void Decode(string bearer);
    string Encrypt(User user);
}