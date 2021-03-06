using System.ComponentModel.DataAnnotations;

namespace Api.Models.UserController;

public class User
{
    [Required] public Guid UserId { get; set; }
    [Required] public int RoleId { get; set; }
    [Required] public string Name { get; set; }
}