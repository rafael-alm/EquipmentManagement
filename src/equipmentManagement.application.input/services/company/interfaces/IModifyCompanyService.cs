using equipmentManagement.domain.aggregates.company.commands;

namespace equipmentManagement.application.input.services.company.interfaces
{
    public interface IModifyCompanyService
    {
        Task Execute(ModifyCompanyCommand data, CancellationToken cancellationToken);
    }
}
