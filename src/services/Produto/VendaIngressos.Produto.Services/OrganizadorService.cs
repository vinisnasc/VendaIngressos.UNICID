using AutoMapper;
using VendaIngressos.Produto.Domain.Entities;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;
using VendaIngressos.Produto.Domain.Interfaces.Repository;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.Services
{
    public class OrganizadorService : IOrganizadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrganizadorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganizadorResult>> BuscarTodosOrganizadores()
        {
            var list = await _unitOfWork.OrganizadorRepository.SelecionarTudo();
            return _mapper.Map<IEnumerable<OrganizadorResult>>(list);
        }

        public async Task CadastrarOrganizador(OrganizadorDTO dto)
        {
            var entity = _mapper.Map<Organizador>(dto);
            await _unitOfWork.OrganizadorRepository.Incluir(entity);
        }
    }
}