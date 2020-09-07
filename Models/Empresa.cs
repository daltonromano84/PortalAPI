using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Models
{

public class Empresa
{

    public Empresa()
    {
        Colaboradores = new List<Colaborador>();
    }

    [Key]
    public int Id { get; set; }

     [Required]
    [MaxLength(250)]
    public string CNPJ { get; set; }


    [Required]
    [MaxLength(250)]
    public string RazaoSocial { get; set; }

    public List<Colaborador> Colaboradores { get; set; }
 
  

}

}