using AutoMapper;
using PortalAPI.Dtos;
using PortalAPI.Models;

namespace PortalAPI.Profiles
{
public class ColaboradoresProfile:Profile
{

public ColaboradoresProfile()
{

    //source -> Target
    CreateMap<Colaborador, ColaboradorReadDto>();
    CreateMap<ColaboradorCreateDto,Colaborador>();
    CreateMap<ColaboradorUpdateDto,Colaborador>();
    CreateMap<Colaborador,ColaboradorUpdateDto>();
    
    
}


}

}