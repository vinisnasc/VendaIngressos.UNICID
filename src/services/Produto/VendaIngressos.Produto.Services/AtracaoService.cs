using AutoMapper;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;
using VendaIngressos.Produto.Domain.Interfaces.Repository;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.Services
{
    public class AtracaoService : BaseService, IAtracaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AtracaoService(IUnitOfWork unitOfWork, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<AtracaoResult>> BuscarTodasAtracoes()
        {
            var list = await _unitOfWork.AtracaoRepository.SelecionarTudo();
            return _mapper.Map<List<AtracaoResult>>(list);
        }

        public async Task<AtracaoResult> BuscarAtracaoPorId(Guid id)
        {
            var entity = await _unitOfWork.AtracaoRepository.SelecionarPorId(id);
            return _mapper.Map<AtracaoResult>(entity);
        }

        public async Task CriarAtracao(AtracaoCreate dto)
        {
            var entity = _mapper.Map<Atracao>(dto);
            await _unitOfWork.AtracaoRepository.Incluir(entity);
        }
    }
}