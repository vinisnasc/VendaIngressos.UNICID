using AutoMapper;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;

namespace VendaIngressos.Produto.CrossCutting.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<OrganizadorDTO, Organizador>().ReverseMap();
            CreateMap<OrganizadorResult, Organizador>().ReverseMap();
            CreateMap<ShowHouseDTO, ShowHouse>().ReverseMap();
            CreateMap<ShowHouseResult, ShowHouse>().ReverseMap();
            CreateMap<MunicipioDTO, Municipio>().ReverseMap();
            CreateMap<MunicipioResult, Municipio>().ReverseMap();
            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            CreateMap<EnderecoResult, Endereco>().ReverseMap();
            CreateMap<UfResult, Uf>().ReverseMap();
            CreateMap<AtracaoDTO, Atracao>().ReverseMap();
            CreateMap<AtracaoResult, Atracao>().ReverseMap();
        }
    }
}