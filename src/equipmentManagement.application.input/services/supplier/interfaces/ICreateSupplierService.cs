using equipmentManagement.application.input.services.product.dto;
using equipmentManagement.application.input.services.supplier.dto;
using equipmentManagement.domain.aggregates.supplier.commands;

namespace equipmentManagement.application.input.services.supplier.interfaces
{
    public interface ICreateSupplierService
    {
        Task<ReturnSupplierCreation> Execute(CreateSupplierCommand data, CancellationToken cancellationToken);
    }
}
