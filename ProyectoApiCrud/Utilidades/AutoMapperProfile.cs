using AutoMapper;
using ProyectoApiCrud.DTOs;
using ProyectoApiCrud.Models;
using System.Globalization;

namespace ProyectoApiCrud.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => origen.FechaContrato.Value.ToString("dd/MM/yyyy")));
            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaContrato, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
