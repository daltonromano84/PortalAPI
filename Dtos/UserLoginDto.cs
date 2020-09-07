using System;
using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Dtos
{

public class UserLoginDto
{
  
    [Required]
    [StringLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(50,MinimumLength=5)]
       public string Password { get; set; }
      


 
}

}