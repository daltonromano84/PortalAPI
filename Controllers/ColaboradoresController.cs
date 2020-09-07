using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PortalAPI.Data;
using PortalAPI.Dtos;
using PortalAPI.Models;

namespace PortalAPI.Controllers
{
    
    //api/colaboradores
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradorRepository _repository;
        private IMapper _mapper;

        public ColaboradoresController(IColaboradorRepository repository,IMapper mapper)
            {

                _repository = repository;
                _mapper = mapper;


            }
        //  private readonly MockColaboradorRepository _repository = new MockColaboradorRepository(); 


            //GET api/colaboradores
            [HttpGet]
            public ActionResult <IEnumerable<ColaboradorReadDto>> GetAllColaboradores()
            {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
                var colaboradorItems = _repository.GetAllColaboradores();    

                return Ok(_mapper.Map<IEnumerable<ColaboradorReadDto>>(colaboradorItems));
            }

            //GET api/colaboradores/5
            [HttpGet("{id}",Name="GetColaboradorById")]
            public ActionResult <ColaboradorReadDto> GetColaboradorById(int id)
            {

               

                    var colaboradorItem = _repository.GetColaboradorById(id);

                    if(colaboradorItem!=null)
                    {
                     return Ok(_mapper.Map<ColaboradorReadDto>(colaboradorItem));

                    }else{

                        return NotFound();
                    }


            }

             //POST api/colaboradores
             [HttpPost]
            public ActionResult <ColaboradorReadDto> CreateColaborador(ColaboradorCreateDto  colaboradorCreateDto)
            {

                var colaboradorModel = _mapper.Map<Colaborador>(colaboradorCreateDto);
                _repository.CreateColaborador(colaboradorModel);
                _repository.SaveChanges();

                var colaboradorReadDto = _mapper.Map<ColaboradorReadDto>(colaboradorModel);


                return CreatedAtRoute(nameof(GetColaboradorById), new { id= colaboradorReadDto.Id},colaboradorReadDto);

         
            }

            //PUT api/colaboradores/{id}
             [HttpPut("{id}")]
            public ActionResult UpdateColaborador(int id,ColaboradorUpdateDto  colaboradorUpdate)
            {

                var colaboradorModelFromRepository = _repository.GetColaboradorById(id);

                if (colaboradorModelFromRepository == null)
                {
                    return NotFound();
                }

                _mapper.Map(colaboradorUpdate,colaboradorModelFromRepository);
                _repository.UpdateColaborador(colaboradorModelFromRepository);

                _repository.SaveChanges();

                return NoContent();

         
            }

               //PUT api/colaboradores/{id}
             [HttpPatch("{id}")]
            public ActionResult PartialColaboradorUpdate(int id, JsonPatchDocument<ColaboradorUpdateDto>  patchDoc)
            {

                var colaboradorModelFromRepository = _repository.GetColaboradorById(id);

                if (colaboradorModelFromRepository == null)
                {
                    return NotFound();
                }

                var colaboradorToPatch = _mapper.Map<ColaboradorUpdateDto>(colaboradorModelFromRepository);
                patchDoc.ApplyTo(colaboradorToPatch,ModelState);

                if (!TryValidateModel(colaboradorToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(colaboradorToPatch,colaboradorModelFromRepository);

                _repository.UpdateColaborador(colaboradorModelFromRepository);
                _repository.SaveChanges();

                return NoContent();

         
            }

            //DELETE api/colaboradores/{id}
            [HttpDelete("{id}")]
            public ActionResult DeleteColaborador(int id)
            {

                 var colaboradorModelFromRepository = _repository.GetColaboradorById(id);

                if (colaboradorModelFromRepository == null)
                {
                    return NotFound();
                }
                _repository.DeleteCommand(colaboradorModelFromRepository);
                _repository.SaveChanges();

                return NoContent();

            }

    }

}