namespace VendaIngressos.Produto.Domain.Entities.DTOs.Results
{
    public class ShowHouseResultFull
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Guid EnderecoId { get; set; }
        public EnderecoResultFull Endereco { get; set; }
    }
    public class EnderecoResultFull
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioResultFull Municipio { get; set; }
    }

    public class MunicipioResultFull
    {
        public Guid Id { get; set; }
        public string NomeMunicipio { get; set; }
        public Guid UfId { get; set; }
        public UfResultFull Uf { get; set; }
    }

    public class UfResultFull
    {
        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
    }
}