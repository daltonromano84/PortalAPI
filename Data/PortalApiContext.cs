using Microsoft.EntityFrameworkCore;
using PortalAPI.Models;

namespace PortalAPI.Data
{
    public class PortalApiContext : DbContext
    {
      public PortalApiContext(DbContextOptions<PortalApiContext> opt): base(opt)
      {
          
      }

      public DbSet<Colaborador> Colaboradores { get; set; }


    }



}