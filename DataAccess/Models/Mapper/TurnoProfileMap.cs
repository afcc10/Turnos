using System;
using AutoMapper;
using DataAccess.Models;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class TurnoProfileMap : Profile
    {
        public TurnoProfileMap()
        {
            CreateMap<Turnos, TurnosDto>().ReverseMap();
        }
    }
}
