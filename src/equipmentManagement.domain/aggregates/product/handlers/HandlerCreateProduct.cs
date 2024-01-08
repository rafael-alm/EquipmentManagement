using equipmentManagement.domain.aggregates.product;
using equipmentManagement.domain.aggregates.product.commands;
using equipmentManagement.domain.aggregates.product.validations;
using equipmentManagement.domain.seedWork.aggregateHandler;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.aggregates.product.handlers
{
    public sealed class HandlerCreateProduct : HandlerCreateAggregate<Product>
    {
        private readonly CreateProductCommand data;

        private HandlerCreateProduct(CreateProductCommand data, INotification notification) : base(notification)
        {
            this.data = data;
        }
        public static HandlerCreateProduct New(CreateProductCommand data, INotification notification)
            => new HandlerCreateProduct(data, notification);

        protected override Product? execute()
        {
            return Product.Create(data, notification);
        }
    }
}
