namespace VendaIngressos.WebApp.MVC.Areas.Produto.Models
{
    public class AtracaoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeIngresso { get; set; }
        public string Poster { get; set; }
        public string Descricao { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public Guid OrganizadorId { get; set; }
        public OrganizadorResult Organizador { get; set; }
        public Guid ShowHouseId { get; set; }
        public ShowHouseResult ShowHouse { get; set; }
    }

    public enum TipoEvento
    {
        Musical,
        Comedia,
        Teatro
    }

    public class ShowHouseResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Guid EnderecoId { get; set; }
        public EnderecoResult Endereco { get; set; }
    }

    public class EnderecoResult
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioResult Municipio { get; set; }
    }

    public class MunicipioResult
    {
        public Guid Id { get; set; }
        public string NomeMunicipio { get; set; }
        public Guid UfId { get; set; }
        public UfResult Uf { get; set; }
    }

    public class UfResult
    {
        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
    }

    public class OrganizadorResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}