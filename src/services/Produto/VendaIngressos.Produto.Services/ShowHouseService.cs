using AutoMapper;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Repository;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.Services
{
    public class ShowHouseService : IShowHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShowHouseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CriarCasaDeShows(ShowHouseDTO dto)
        {
            var entity = _mapper.Map<ShowHouse>(dto);
            entity.EnderecoId = await CadastrarEndereco(dto.Endereco);
            entity.Endereco = null;
            await _unitOfWork.ShowHouseRepository.Incluir(entity);
        }

        private async Task<Guid> CadastrarMunicipio(MunicipioDTO dto)
        {
           var entity = await _unitOfWork.MunicipioRepository.Buscar(x => x.UfId == dto.UfId && x.NomeMunicipio == dto.NomeMunicipio);

            if (entity != null)
                return entity.Id;

            entity = _mapper.Map<Municipio>(dto);

            await _unitOfWork.MunicipioRepository.Incluir(entity);

            return entity.Id;
        }

        private async Task<Guid> CadastrarEndereco(EnderecoDTO dto)
        {
            var entity = await _unitOfWork.EnderecoRepository.Buscar(x => x.Cep == dto.Cep && x.Numero == dto.Numero);

            if (entity != null)
                return entity.Id;

            entity = _mapper.Map<Endereco>(dto);
            entity.MunicipioId = await CadastrarMunicipio(dto.Municipio);
            await _unitOfWork.EnderecoRepository.Incluir(entity);
            return entity.Id;
        }
    }
}