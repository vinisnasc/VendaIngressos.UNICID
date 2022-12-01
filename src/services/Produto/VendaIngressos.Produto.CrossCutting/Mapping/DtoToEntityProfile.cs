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
            CreateMap<OrganizadorCreate, Organizador>().ReverseMap();
            CreateMap<OrganizadorResult, Organizador>().ReverseMap();

            CreateMap<ShowHouseCreate, ShowHouse>().ReverseMap();
            CreateMap<ShowHouseResult, ShowHouse>().ReverseMap();
            CreateMap<ShowHouseResultFull, ShowHouse>().ReverseMap();
            CreateMap<ShowHouseUpdate, ShowHouse>().ReverseMap();

            CreateMap<MunicipioDTO, Municipio>().ReverseMap();
            CreateMap<MunicipioResult, Municipio>().ReverseMap();
            CreateMap<MunicipioResultFull, Municipio>().ReverseMap();

            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            CreateMap<EnderecoResult, Endereco>().ReverseMap();
            CreateMap<EnderecoResultFull, Endereco>().ReverseMap();

            CreateMap<UfResult, Uf>().ReverseMap();
            CreateMap<UfResultFull, Uf>().ReverseMap();

            CreateMap<AtracaoCreate, Atracao>().ReverseMap();
            CreateMap<AtracaoResult, Atracao>().ReverseMap();
            CreateMap<AtracaoResultFull, Atracao>().ReverseMap();
        }
    }
}