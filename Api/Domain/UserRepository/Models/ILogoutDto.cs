namespace Domain.UserRepository.Models;

public interface ILogoutDto
{
    public Guid UserId { get; set; }
}