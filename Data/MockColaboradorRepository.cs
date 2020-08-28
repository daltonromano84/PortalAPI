
using System.Collections.Generic;
using PortalAPI.Models;

using System;

namespace PortalAPI.Data
{

    public class MockColaboradorRepository : IColaboradorRepository
    {

        
        public IEnumerable<Colaborador> GetColaboradores()
        {
            var colaboradores = new List<Colaborador>
            {
                new Colaborador{
                Id = 0,
                IdCargo=1,
                IdEmpresa=1,
                Matricula= 001,
                Nome = "Dalton Romano",
                DataAdmissao=  DateTime.Now,
                DataDemissao = null
                },

                new Colaborador{
                Id = 1,
                IdCargo=2,
                IdEmpresa=1,
                Matricula= 001,
                Nome = "Daniel Ribeiro Romano",
                DataAdmissao=  DateTime.Now,
                DataDemissao = null
                },
                new Colaborador{
                Id = 2,
                IdCargo=3,
                IdEmpresa=1,
                Matricula= 001,
                Nome = "Gabriel Romano",
                DataAdmissao=  DateTime.Now,
                DataDemissao = null},


            };

            return colaboradores;
        }
        public Colaborador GetColaboradorById(int id)
        {
            return new Colaborador{
                Id =0,
                IdCargo=1,
                IdEmpresa=1,
                Matricula= 001,
                Nome = "Dalton Romano",
                DataAdmissao=  DateTime.Now,
                DataDemissao = null

            };
        }

    }

}