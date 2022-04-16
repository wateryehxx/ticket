namespace Domain.UserRepository.Models;

public interface ILoginDto
{
    public string Name { get; set; }
    public string Password { get; set; }
}