using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;

namespace VendaIngressos.Produto.Domain.Interfaces.Service
{
    public interface IAtracaoService
    {
        Task CriarAtracao(AtracaoDTO dto);
        Task<List<AtracaoResult>> BuscarTodasAtracoes();
    }
}