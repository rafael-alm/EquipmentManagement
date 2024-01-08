using equipmentManagement.domain.aggregates.product;

namespace equipmentManagement.application.input.services.product.interfaces
{
    public interface IProductAppRepository
    {
        Task<Product> GetById(Guid id, CancellationToken cancellationToken);
        Task Add(Product entity, CancellationToken cancellationToken);
        void Update(Product entity);
    }
}
