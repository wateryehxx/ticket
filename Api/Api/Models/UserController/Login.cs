using System.ComponentModel.DataAnnotations;
using Domain.UserRepository.Models;

namespace Api.Models.UserController;

public class Login : ILoginDto
{
    [Required] public string Name { get; set; }
    [Required] public string Password { get; set; }
}