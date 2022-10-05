using AutoMapper;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Entities.DTOs;

namespace VendaIngressos.Produto.CrossCutting.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<OrganizadorDTO, Organizador>().ReverseMap();
        }
    }
}