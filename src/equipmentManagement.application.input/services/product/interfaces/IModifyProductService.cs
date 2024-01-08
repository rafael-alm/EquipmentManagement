using equipmentManagement.domain.aggregates.product.commands;

namespace equipmentManagement.application.input.services.product.interfaces
{
    public interface IModifyProductService
    {
        Task Execute(ModifyProductCommand data, CancellationToken cancellationToken);
    }
}
