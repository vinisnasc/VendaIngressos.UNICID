namespace VendaIngressos.Produto.Domain.Entities.DTOs
{
    public class ShowHouseCreate
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }

    public class EnderecoDTO
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public MunicipioDTO Municipio { get; set; }
    }

    public class MunicipioDTO
    {
        public string NomeMunicipio { get; set; }
        public Guid UfId { get; set; }
    }
}