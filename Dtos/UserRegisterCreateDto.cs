using System;
using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Dtos
{

public class UserRegisterCreateDto
{
  
    [Required]
    [StringLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(50,MinimumLength=5)]
       public string Password { get; set; }

      
     [Required]
    [StringLength(50,MinimumLength=5)]
       public string ConfirmPassword { get; set; }

       [Required]
    public int IdEmpresa { get; set; }
    [Required]

    public int Matricula { get; set; }
  [Required]

    public int IdCargo { get; set; }

      
    [Required]
    [MaxLength(250)]
    public string Nome { get; set; }
  
    [Required]
    public DateTime   DataAdmissao { get; set; }   
    public DateTime?   DataDemissao { get; set; }   

 
}

}