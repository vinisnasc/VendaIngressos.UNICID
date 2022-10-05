using VendaIngressos.Produto.Domain.Entities.DTOs;

namespace VendaIngressos.Produto.Domain.Interfaces.Service
{
    public interface IOrganizadorService 
    {
        Task CadastrarOrganizador(OrganizadorDTO dto);
    }
}