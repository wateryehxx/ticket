namespace Domain.UserRepository;

public interface IUpdateUserDto
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}