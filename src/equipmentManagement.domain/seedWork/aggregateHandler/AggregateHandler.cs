using equipmentManagement.domain.seedWork.entities.interfaces;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.seedWork.aggregateHandler
{
    public abstract class AggregateHandler<TEntity> : IAggregateHandler<TEntity>
     where TEntity : IAggregateRoot<TEntity>, IEntity
    {
        protected readonly INotification notification;

        protected AggregateHandler(INotification notification)
            => this.notification = notification;

        bool IAggregateHandler.Success => !notification.HasError;
        public INotification Notification => notification;

        void IAggregateHandler<TEntity>.Execute(TEntity entity)
            => execute(entity);

        protected abstract void execute(TEntity entity);
    }

}
