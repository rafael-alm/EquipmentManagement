using equipmentManagement.domain.objectValues;
using System.Text;

namespace equipmentManagement.domain.aggregates.supplier
{
    public interface ISupplierRepository
    {
        Task<bool> CNPJHasAlreadyBeenNotifiedToAnotherSupplier(CNPJ cnpj, Guid? exceptSupplierWithId = default);
    }
}
