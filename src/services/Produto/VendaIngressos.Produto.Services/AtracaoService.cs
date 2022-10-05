using VendaIngressos.Produto.Domain.Interfaces.Repository;

namespace VendaIngressos.Produto.Services
{
    public class AtracaoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtracaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}