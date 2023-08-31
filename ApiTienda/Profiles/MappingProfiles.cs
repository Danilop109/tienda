using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTienda.Dtos;
using AutoMapper;
using Core.Entities;

namespace ApiTienda.Profiles;
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
        CreateMap<Pais, PaisDto>().ReverseMap();

        // CreateMap<Estado, EstadoDto>()
        // .ForMember(dest => dest.IdEstado, opt => opt.MapForm)


        }
    }
