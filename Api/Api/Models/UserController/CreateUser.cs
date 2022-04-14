using System.ComponentModel.DataAnnotations;
using Domain.UserRepository;

namespace Api.Models.UserController;

public class CreateUser : ICreateUserDto
{
    [Required] public int RoleId { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Password { get; set; }
}