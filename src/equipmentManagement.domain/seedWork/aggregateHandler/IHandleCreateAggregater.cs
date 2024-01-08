using equipmentManagement.domain.seedWork.entities.interfaces;

namespace equipmentManagement.domain.seedWork.aggregateHandler
{
    internal interface IHandleCreateAggregater<TEntity> : IAggregateHandler
        where TEntity : IAggregateRoot<TEntity>, IEntity
    {
        public TEntity? Execute();
    }
}
