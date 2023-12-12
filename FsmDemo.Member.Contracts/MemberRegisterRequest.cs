using System.ComponentModel.DataAnnotations;

namespace FsmDemo.Contracts;

public class MemberRegisterRequest
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}