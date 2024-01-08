using equipmentManagement.application.input.services.product.dto;
using equipmentManagement.domain.aggregates.product.commands;

namespace equipmentManagement.application.input.services.product.interfaces
{
    public interface ICreateProductService
    {
        Task<ReturnProductCreation> Execute(CreateProductCommand data, CancellationToken cancellationToken);
    }
}
