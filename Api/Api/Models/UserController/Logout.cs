using System.ComponentModel.DataAnnotations;
using Domain.UserRepository.Models;

namespace Api.Models.UserController;

public class Logout : ILogoutDto
{
    [Required] public Guid UserId { get; set; }
}