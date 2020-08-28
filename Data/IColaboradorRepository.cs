using System.Collections.Generic;
using PortalAPI.Models;

namespace PortalAPI.Data
{

 public interface IColaboradorRepository
 {
     IEnumerable<Colaborador> GetColaboradores();
     Colaborador GetColaboradorById(int id);
 }

}