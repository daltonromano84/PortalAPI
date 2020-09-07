using System;
using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Dtos
{

public class ColaboradorCreateDto
{
  
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