using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VendaIngressos.Identidade.API.Data
{
    public class IdentidadeContexto : IdentityDbContext
    {
        public IdentidadeContexto(DbContextOptions<IdentidadeContexto> options) : base(options) { }
    }
}