using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendaIngressos.Produto.Domain.Entities.DTOs;
using VendaIngressos.Produto.Domain.Interfaces.Service;

namespace VendaIngressos.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowHouseController : ControllerBase
    {
        private readonly IShowHouseService _showHouseService;

        public ShowHouseController(IShowHouseService showHouseService)
        {
            _showHouseService = showHouseService ?? throw new ArgumentNullException(nameof(showHouseService));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarShowHouse(ShowHouseDTO dto)
        {
            await _showHouseService.CriarCasaDeShows(dto);
            return Ok();
        }
    }
}