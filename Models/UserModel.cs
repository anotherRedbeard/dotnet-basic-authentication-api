namespace WebApi.Models;

using System.ComponentModel.DataAnnotations;

public class UserModel
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
