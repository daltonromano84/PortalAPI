using System.Collections.Generic;
using PortalAPI.Models;

namespace PortalAPI.Data
{

 public interface IColaboradorRepository
 {

     bool SaveChanges();
     IEnumerable<Colaborador> GetAllColaboradores();
     Colaborador GetColaboradorById(int id);

     void CreateColaborador(Colaborador colaborador);
     void UpdateColaborador(Colaborador colaborador);

     void DeleteCommand(Colaborador colaborador);
 }

}