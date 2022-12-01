using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.API.Controllers
{
    [Route("api/[controller]")]
    public class OrganizadorController : BaseController
    {
        private readonly IOrganizadorService _organizadorService;

        public OrganizadorController(IOrganizadorService organizadorService, INotificador notificador) : base(notificador)
        {
            _organizadorService = organizadorService ?? throw new ArgumentNullException(nameof(organizadorService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BuscarTodosOrganizadores()
        {
            var list = await _organizadorService.BuscarTodosOrganizadores();
            return CustomResponse(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarNovoOrganizador(OrganizadorCreate dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _organizadorService.CadastrarOrganizador(dto);

            return CustomResponse(dto);
        }
        /*
        public async Task<IActionResult> AtualizarOrganizador(Guid id, OrganizadorDTO dto)
        {
            /*if (id != dto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(dto);
            }

            return Ok();
        }*/
    }
}