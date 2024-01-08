using equipmentManagement.domain.aggregates.product;
using equipmentManagement.domain.aggregates.product.commands;
using equipmentManagement.domain.aggregates.product.validations;
using equipmentManagement.domain.aggregates.supplier.commands;
using equipmentManagement.domain.seedWork.aggregateHandler;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.aggregates.product.handlers
{
    public sealed class HandlerModifyProduct : AggregateHandler<Product>
    {
        private readonly ModifyProductCommand data;

        private HandlerModifyProduct(ModifyProductCommand data, INotification notification) : base(notification)
        {
            this.data = data;
        }

        public static HandlerModifyProduct New(ModifyProductCommand data, INotification notification)
            => new HandlerModifyProduct(data, notification);

        protected override void execute(Product entity)
        {
            entity.Modify(data, notification);
        }
    }
}
