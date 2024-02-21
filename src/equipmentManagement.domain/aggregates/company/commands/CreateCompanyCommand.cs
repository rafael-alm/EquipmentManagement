namespace equipmentManagement.domain.aggregates.company.commands
{
    public struct CreateCompanyCommand
    {
        public string RegisteredName { get; set; }
        public string Name { get; set; }
        public int TypeOfFacility { get; set; }
        public string CNPJ { get; set; }
        //public IEnumerable<IDadosDoEndereco> Enderecos { get; }

        //public interface IDadosDoEndereco
        //{
        //    public string Street { get; }
        //    public string Number { get; }
        //    public string Complement { get; }
        //    public string Neighborhood1 { get; }
        //    public string CityId { get; }
        //    public string PostalCode { get; }
        //    public bool Main { get; }
        //}
    }
}
