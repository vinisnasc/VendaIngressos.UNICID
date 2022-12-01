using AutoMapper;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;
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
            if (notificador is null)
                throw new ArgumentNullException(nameof(notificador));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<ShowHouseResult>> BuscarTodasCasasDeShowAsync()
        {
            var list = await _unitOfWork.ShowHouseRepository.SelecionarTudo();
            return _mapper.Map<IEnumerable<ShowHouseResult>>(list);
        }

        public async Task<ShowHouseResultFull> BuscarCasaDeShowAsync(Guid id)
        {
            var entity = await _unitOfWork.ShowHouseRepository.SelecionarPorId(id);
            if (entity == null)
            {
                Notificar("Casa de show não encontrada!");
                return null;
            }

            return _mapper.Map<ShowHouseResultFull>(entity);
        }

        public async Task CriarCasaDeShowsAsync(ShowHouseCreate dto)
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

        public async Task AlterarCasaDeShowsAsync(ShowHouseUpdate dto, Guid id)
        {
            var entidade = await _unitOfWork.ShowHouseRepository.SelecionarPorId(id);

            if (entidade == null)
            {
                Notificar("Casa de show não encontrada!");
                return;
            }

            var municipio = await _unitOfWork.MunicipioRepository.Buscar(x => x.UfId == dto.Endereco.Municipio.UfId &&
                                                               x.NomeMunicipio == dto.Endereco.Municipio.NomeMunicipio);
            if (municipio == null)
            {
                var dtoMunicipio = _mapper.Map<Municipio>(dto.Endereco.Municipio);



                await _unitOfWork.MunicipioRepository.Incluir(dtoMunicipio);
                municipio = await _unitOfWork.MunicipioRepository.Buscar(x => x.UfId == dto.Endereco.Municipio.UfId &&
                                                              x.NomeMunicipio == dto.Endereco.Municipio.NomeMunicipio);
            }

            var endereco = await _unitOfWork.EnderecoRepository.Buscar(x => x.Cep == dto.Endereco.Cep &&
                                                                 x.Numero == dto.Endereco.Numero &&
                                                                 x.Complemento == dto.Endereco.Complemento);
            if (endereco == null)
            {
                var dtoEndereco = _mapper.Map<Endereco>(dto.Endereco);
                dtoEndereco.MunicipioId = municipio.Id;

                if (!ExecutarValidacao(new EnderecoValidation(), dtoEndereco))
                    return;

                await _unitOfWork.EnderecoRepository.Incluir(dtoEndereco);
                endereco = await _unitOfWork.EnderecoRepository.Buscar(x => x.Cep == dto.Endereco.Cep &&
                                                                  x.Numero == dto.Endereco.Numero &&
                                                                  x.Complemento == dto.Endereco.Complemento);
            }

            entidade.Telefone = dto.Telefone;
            entidade.Nome = dto.Nome;
            entidade.EnderecoId = endereco.Id;

            if (!ExecutarValidacao(new ShowHouseValidation(), entidade))
                return;

            await _unitOfWork.ShowHouseRepository.Alterar(entidade);
        }
    }
}