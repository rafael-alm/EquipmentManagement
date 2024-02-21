using equipmentManagement.application.output.dto.company;
using equipmentManagement.application.output.seedWork;

namespace equipmentManagement.application.output.interfaces
{
    public interface IReadProductRepository
    {
        Task<ProductDTO> GetByIdAsync(Guid companyId, CancellationToken cancellationToken);
        Task<ProductDTO> GetByCodeAsync(int code, CancellationToken cancellationToken);
        Task<IPaging<ProductForPagingDTO>> ResearchAsync(ProductPaginationFilter filter, CancellationToken cancellationToken);
    }
}
