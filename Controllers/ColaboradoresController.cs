using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PortalAPI.Data;
using PortalAPI.Models;

namespace PortalAPI.Controllers
{
    
    //api/colaboradores
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradorRepository _repository;

        public ColaboradoresController(IColaboradorRepository repository)
            {

                _repository = repository;


            }
        //  private readonly MockColaboradorRepository _repository = new MockColaboradorRepository(); 


            //GET api/colaboradores
            [HttpGet]
            public ActionResult <IEnumerable<Colaborador>> GetAllColaboradores()
            {

                    var colaboradorItems = _repository.GetColaboradores();    

                        return Ok(colaboradorItems);
            }

            //GET api/colaboradores/5
            [HttpGet("{id}")]
            public ActionResult <Colaborador> GetColaboradorById(int id)
            {

                    var colaboradorItem = _repository.GetColaboradorById(id);

                    return Ok(colaboradorItem);


            }

    }

}