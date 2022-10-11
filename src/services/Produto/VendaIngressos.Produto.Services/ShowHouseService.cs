using AutoMapper;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Repository;
using VendaIngressos.Produto.Domain.Interfaces.Service;
using VendaIngressos.Produto.Domain.Validations;

namespace VendaIngressos.Produto.Services
{
    public class ShowHouseService : BaseService, IShowHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShowHouseService(IMapper mapper, IUnitOfWork unitOfWork, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CriarCasaDeShows(ShowHouseDTO dto)
        {
            var entity = _mapper.Map<ShowHouse>(dto);

            if (!ExecutarValidacao(new ShowHouseValidation(), entity) || !ExecutarValidacao(new EnderecoValidation(), entity.Endereco))
                return;

            if (await _unitOfWork.MunicipioRepository.Buscar(x => x.UfId == dto.Endereco.Municipio.UfId &&
                                                                x.NomeMunicipio == dto.Endereco.Municipio.NomeMunicipio) != null)
                entity.Endereco.Municipio = null;

            if (await _unitOfWork.EnderecoRepository.Buscar(x => x.Cep == dto.Endereco.Cep &&
                                                                 x.Numero == dto.Endereco.Numero &&
                                                                 x.Complemento == dto.Endereco.Complemento) != null)
                entity.Endereco = null;

            await _unitOfWork.ShowHouseRepository.Incluir(entity);
        }
    }
}