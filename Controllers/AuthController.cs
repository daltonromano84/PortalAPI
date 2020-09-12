using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserRepository _userRepository;
        private IColaboradorRepository _colaboradorRepository;
         private IMapper _mapper;

        public AuthController(IUserRepository userRepository,IColaboradorRepository colaboradorRepository,IMapper mapper) 
        {

            _userRepository = userRepository;
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
            
            
        }
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromBody]UserRegisterCreateDto model)
        {

                if(ModelState.IsValid)
                {

                  var result = await _userRepository.RegisterUserAsync(model);

                  if(result.IsSuccess){

           

               //  var colaboradorModel = _mapper.Map<Colaborador>(model);

               Colaborador colaborador = new Colaborador{

                   IdEmpresa = model.IdEmpresa,
                   IdCargo = model.IdCargo,
                   DataAdmissao =  DateTime.Now,
                   Matricula = model.Matricula,
                   Nome = model.Nome
                  
                   
               };


                _colaboradorRepository.CreateColaborador(colaborador);
                _colaboradorRepository.SaveChanges();

              //  var colaboradorReadDto = _mapper.Map<ColaboradorReadDto>(colaboradorModel);

                  return Ok(result);

                  }
                


                  return BadRequest(result);

                }


                return BadRequest("Some properties are not valid");

        }

         // /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserLoginDto model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userRepository.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    //await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
     

    }

}