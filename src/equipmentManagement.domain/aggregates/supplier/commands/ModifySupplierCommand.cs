using equipmentManagement.domain.objectValues;

namespace equipmentManagement.domain.aggregates.supplier.commands
{
    public struct ModifySupplierCommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public CNPJ CNPJ { get; set; }
    }
}
