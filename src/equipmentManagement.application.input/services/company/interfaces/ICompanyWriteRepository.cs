using equipmentManagement.domain.aggregates.company;

namespace equipmentManagement.application.input.services.company.interfaces
{
    public interface ICompanyWriteRepository
    {
        Task Add(Company entity, CancellationToken cancellationToken);
        void Update(Company entity);
    }
}
