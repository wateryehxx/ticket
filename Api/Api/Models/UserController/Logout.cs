using System.ComponentModel.DataAnnotations;
using Domain.UserRepository;

namespace Api.Models.UserController;

public class Logout : ILogoutDto
{
    [Required] public Guid UserId { get; set; }
}