using AutoMapper;
using GestorTareas.DTOs;
using GestorTareas.Models;

namespace GestorTareas.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<CategoriaCreacionDTO, Categoria>();

            CreateMap<List<Categoria>, CategoriasDTO>().ReverseMap();

            CreateMap<Proyecto, ProyectoDTO>().ReverseMap();
            CreateMap<ProyectoCreacionDTO, Proyecto>();

            CreateMap<List<Proyecto>, ProyectoDTO>().ReverseMap();
        }
    }
}
