using equipmentManagement.application.input.services.company.dto;
using equipmentManagement.domain.aggregates.company.commands;

namespace equipmentManagement.application.input.services.company.interfaces
{
    public interface ICreateCompanyService
    {
        Task<ReturnCompanyCreation> Execute(CreateCompanyCommand data, CancellationToken cancellationToken);
    }
}
