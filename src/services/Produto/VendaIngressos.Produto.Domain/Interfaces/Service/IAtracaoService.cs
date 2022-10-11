using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;

namespace VendaIngressos.Produto.Domain.Interfaces.Service
{
    public interface IAtracaoService
    {
        Task<List<AtracaoResult>> BuscarTodasAtracoes();
        Task<AtracaoResult> BuscarAtracaoPorId(Guid id);
        Task CriarAtracao(AtracaoDTO dto);
    }
}