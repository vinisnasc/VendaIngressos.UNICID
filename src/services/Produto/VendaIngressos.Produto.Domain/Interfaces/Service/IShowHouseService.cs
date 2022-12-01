using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Entities.DTOs.Results;

namespace VendaIngressos.Produto.Domain.Interfaces.Service
{
    public interface IShowHouseService
    {
        Task<ShowHouseResultFull> BuscarCasaDeShowAsync(Guid id);
        Task<IEnumerable<ShowHouseResult>> BuscarTodasCasasDeShowAsync();
        Task CriarCasaDeShowsAsync(ShowHouseCreate dto);
        Task AlterarCasaDeShowsAsync(ShowHouseUpdate dto, Guid id);
    }
}