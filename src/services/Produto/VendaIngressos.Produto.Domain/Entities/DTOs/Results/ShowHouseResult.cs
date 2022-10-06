namespace VendaIngressos.Produto.Domain.Entities.DTOs.Results
{
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
}