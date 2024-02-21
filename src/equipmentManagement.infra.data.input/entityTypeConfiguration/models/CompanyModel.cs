using equipmentManagement.infra.data.input.seedWork;

namespace equipmentManagement.infra.data.input.entityTypeConfiguration.models
{
    internal sealed class CompanyModel: PersistenceModel
    {
        public string RegisteredName { get; private set; }
        public string Name { get; private set; }
        public int TypeOfFacility { get; private set; }
        public string CNPJ { get; private set; }
        public bool Active { get; private set; }
        public DateTime LastUpdate { get; private set; }
    }
}
