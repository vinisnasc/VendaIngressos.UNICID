using AutoMapper;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;
using VendaIngressos.Produto.Domain.Interfaces.Repository;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.Services
{
    public class AtracaoService : IAtracaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AtracaoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }

        public async Task<List<AtracaoResult>> BuscarTodasAtracoes()
        {
            var list = await _unitOfWork.AtracaoRepository.SelecionarTudo();
            return _mapper.Map<List<AtracaoResult>>(list);
        }

        public async Task CriarAtracao(AtracaoDTO dto)
        {
            var entity = _mapper.Map<Atracao>(dto);
            await _unitOfWork.AtracaoRepository.Incluir(entity);
        }
    }
}