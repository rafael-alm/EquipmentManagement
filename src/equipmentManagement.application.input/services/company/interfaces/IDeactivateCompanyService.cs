using equipmentManagement.domain.seedWork.objectValues;

namespace equipmentManagement.application.input.services.company.interfaces
{
    public interface IDeactivateCompanyService
    {
        Task Execute(EntityIdentity id, CancellationToken cancellationToken);
    }
}
