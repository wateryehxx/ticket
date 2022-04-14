namespace Domain.UserRepository;

public interface ICreateUserDto
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}