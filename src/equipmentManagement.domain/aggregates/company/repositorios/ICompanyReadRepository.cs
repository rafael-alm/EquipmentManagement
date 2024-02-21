using equipmentManagement.domain.aggregates.company;
using equipmentManagement.domain.objectValues;
using equipmentManagement.domain.seedWork.objectValues;

namespace inspecao.administrActive.dominio.modelos.empresa.repositorios
{
    public interface ICompanyReadRepository
    {
        Task<Company> GetById(EntityIdentity id, CancellationToken cancellationToken);
        Task<bool> CNPJHasAlreadyBeenInformed(CNPJ cnpj, EntityIdentity companyId, CancellationToken cancellationToken = default);
    }
}
