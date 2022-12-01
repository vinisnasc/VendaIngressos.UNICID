using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.API.Controllers
{
    [Route("api/[controller]")]
    public class ShowHouseController : BaseController
    {
        private readonly IShowHouseService _showHouseService;

        public ShowHouseController(IShowHouseService showHouseService, INotificador notificador) : base(notificador)
        {
            _showHouseService = showHouseService ?? throw new ArgumentNullException(nameof(showHouseService));
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuscarShowHouse(Guid id)
        {
            var result = await _showHouseService.BuscarCasaDeShowAsync(id);
            return CustomResponse(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BuscarTodasShowHouses()
        {
            return CustomResponse(await _showHouseService.BuscarTodasCasasDeShowAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarShowHouse(ShowHouseCreate dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _showHouseService.CriarCasaDeShowsAsync(dto);
            return CustomResponse();
        }

        [HttpPut]
        public async Task<IActionResult> EditarShowHouseAsync(ShowHouseUpdate dto, Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _showHouseService.AlterarCasaDeShowsAsync(dto, id);
            return CustomResponse();
        }
    }
}