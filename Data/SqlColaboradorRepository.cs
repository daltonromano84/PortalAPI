using System.Collections.Generic;
using System.Linq;
using PortalAPI.Models;

namespace PortalAPI.Data
{

    public class SqlColaboradorRepository : IColaboradorRepository
    {
        private readonly PortalApiContext _context;

        public SqlColaboradorRepository(PortalApiContext context)
    {
        _context = context;       
    }

        public void CreateColaborador(Colaborador colaborador)
        {
            if( colaborador ==null){

                throw new System.ArgumentNullException((nameof(colaborador)));
            }
            else{
                _context.Add(colaborador);

            }
           
        }

   
        public IEnumerable<Colaborador> GetAllColaboradores()
        {
            return _context.Colaboradores.ToList();
        }

        public Colaborador GetColaboradorById(int id)
        {
            return _context.Colaboradores.FirstOrDefault(c=>c.Id == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateColaborador(Colaborador colaborador)
        {
        // nothing
        }

         public void DeleteCommand(Colaborador colaborador)
        {
            if( colaborador ==null){

                throw new System.ArgumentNullException((nameof(colaborador)));
            }
            else{
                _context.Remove(colaborador);

        }
    }



    }


}