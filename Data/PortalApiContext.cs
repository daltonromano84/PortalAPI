
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Models;

namespace PortalAPI.Data
{
 
 public class PortalApiContext:DbContext
    {

        public PortalApiContext(DbContextOptions<PortalApiContext> options):base(options)
        {

        }

        public DbSet<Colaborador> Colaboradores { get; set; } 
        public DbSet<Empresa> Empresas { get; set; }         
    }
}


