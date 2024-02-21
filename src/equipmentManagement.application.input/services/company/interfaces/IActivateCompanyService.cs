using equipmentManagement.domain.seedWork.objectValues;

namespace equipmentManagement.application.input.services.company.interfaces
{
    public interface IActivateCompanyService
    {
        Task Execute(EntityIdentity id, CancellationToken cancellationToken);
    }
}
