using DbContext.Ticket;
using DbContext.Ticket.Tables;
using Domain.UserRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.UserRepository;

public class UserRepositoryRepository : IUserRepository
{
    private readonly TicketContext _db;

    public UserRepositoryRepository(TicketContext db)
    {
        _db = db;
    }

    public async ValueTask<User> Login(ILoginDto dto)
    {
        return await _db.Users.SingleAsync(u => u.Name == dto.Name.Trim() &&
                                                u.Password == dto.Password.Trim()
                                                    .ToMd5());
    }

    public void Logout(ILogoutDto dto)
    {
    }

    public async ValueTask Create(ICreateUserDto dto)
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            RoleId = dto.RoleId,
            Name = dto.Name,
            Password = dto.Password
        };

        await _db.AddAsync(user);
    }

    public async ValueTask Update(IUpdateUserDto dto)
    {
        var user = await _db.Users.SingleAsync(u => u.UserId == dto.UserId);
        user.RoleId = dto.RoleId;
        user.Name = dto.Name;
        user.Password = dto.Password.Trim()
            .ToMd5();
    }

    public void Delete(Guid userId)
    {
        var user = _db.Users.Single(u => u.UserId == userId);
        _db.Users.Remove(user);
    }

    public async ValueTask<List<User>> GetAll()
    {
        return await _db.Users.ToListAsync();
    }

    public User Get(Guid userId)
    {
        return _db.Users.Single(u => u.UserId == userId);
    }
}