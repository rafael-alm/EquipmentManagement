namespace equipmentManagement.domain.aggregates.company.commands
{
    public struct ModifyCompanyCommand
    {
        public string Id { get; set; }
        public string RegisteredName { get; set; }
        public string Name { get; set; }
        public int TypeOfFacility { get; set; }
        public string CNPJ { get; set; }
        //public IEnumerable<IDadosDoEndereco> Enderecos { get; }

        //public interface IDadosDoEndereco
        //{
        //    public string Id { get; }
        //    public string Logradouro { get; }
        //    public string Numero { get; }
        //    public string Complemento { get; }
        //    public string Bairro { get; }
        //    public string IdDaCidade { get; }
        //    public string Cep { get; }
        //    public bool Principal { get; }
        //}
    }
}
