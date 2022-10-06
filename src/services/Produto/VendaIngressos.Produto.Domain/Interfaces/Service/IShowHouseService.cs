using VendaIngressos.Produto.Domain.Entities.DTOs;

namespace VendaIngressos.Produto.Domain.Interfaces.Service
{
    public interface IShowHouseService
    {
        Task CriarCasaDeShows(ShowHouseDTO dto);
    }
}