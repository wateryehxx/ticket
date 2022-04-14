namespace Domain.UserRepository;

public interface ILoginDto
{
    public string Name { get; set; }
    public string Password { get; set; }
}