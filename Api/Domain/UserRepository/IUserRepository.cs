using DbContext.Ticket.Tables;

namespace Domain.UserRepository;

public interface IUserRepository
{
    ValueTask Create(ICreateUserDto dto);
    void Delete(Guid userId);
    User Get(Guid userId);
    ValueTask<List<User>> GetAll();
    ValueTask<User> Login(ILoginDto dto);
    void Logout(ILogoutDto dto);
    ValueTask Update(IUpdateUserDto dto);
}