using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalAPI.Models
{

public class Colaborador
{

    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Empresa")]
    public int IdEmpresa { get; set; }
    [Required]
    public int Matricula { get; set; }
    [Required]
    [MaxLength(250)]
    public string Nome { get; set; }
    [Required]
    public int IdCargo { get; set; }
    [Required]
    public DateTime   DataAdmissao { get; set; }   
    public DateTime?   DataDemissao { get; set; }   

    public Empresa Empresa { get; set; }
 

}

}