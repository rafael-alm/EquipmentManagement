using equipmentManagement.application.input.seedWork.repository;

namespace equipmentManagement.infra.data.input.seedWork
{
    public abstract class Repository<TModel, TId> : IRepository<TModel, TId>
        where TModel : class
        where TId : struct
    {
        protected readonly ContextequipmentManagement context;
        protected Repository(IDbContext context)
            => this.context = context as ContextequipmentManagement;
    }
}
