using System.ComponentModel.DataAnnotations;

namespace Api.Models.UserController;

public class LoginResponse
{
    [Required] public string JwtAuth { get; set; }
}