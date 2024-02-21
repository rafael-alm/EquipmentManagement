using equipmentManagement.application.input.seedWork.repository;

namespace equipmentManagement.infra.data.input
{
    public class UnitOfWork : IDbContext
    {
        private readonly ContextEquipmentManagement context;

        public UnitOfWork(ContextEquipmentManagement context)
            => this.context = context;

        Task IDbContext.Commit(CancellationToken cancellationToken)
            => context.Commit(cancellationToken);

        ValueTask IDbContext.DisposeAsync()
            => context.DisposeAsync();

        Task IDbContext.Rollback(CancellationToken cancellationToken)
            => context.Rollback();

        Task<int> IDbContext.SaveChangesAsync(CancellationToken cancellationToken)
            => context.SaveChangesAsync();
    }
}
