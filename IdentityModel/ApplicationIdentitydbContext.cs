using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.IdentityModel
{
    public class ApplicationIdentitydbContext:IdentityDbContext
    {

        public ApplicationIdentitydbContext(DbContextOptions<ApplicationIdentitydbContext> options):base(options)
        {

        }

        public DbSet<User> Usuarios { get; set; }
    }
}
