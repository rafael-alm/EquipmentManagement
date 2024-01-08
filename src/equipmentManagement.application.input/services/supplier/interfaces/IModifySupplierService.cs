using equipmentManagement.domain.aggregates.supplier.commands;

namespace equipmentManagement.application.input.services.supplier.interfaces
{
    public interface IModifySupplierService
    {
        Task Execute(ModifySupplierCommand data, CancellationToken cancellationToken);
    }
}
