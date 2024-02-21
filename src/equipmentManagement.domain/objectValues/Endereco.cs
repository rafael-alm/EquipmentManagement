namespace equipmentManagement.domain.objectValues
{
    public record Endereco
    {
        public Endereco(string logradouro, string numero, string complemento, string bairro, string idDaCidade, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            IdDaCidade = idDaCidade;
            Cep = cep;
        }

        public string Logradouro { get; init; }
        public string Numero { get; init; }
        public string Complemento { get; init; }
        public string Bairro { get; init; }
        public string IdDaCidade { get; init; }
        public string Cep { get; init; }
    }
}
