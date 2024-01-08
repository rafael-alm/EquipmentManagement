using equipmentManagement.domain.aggregates.product;
using equipmentManagement.domain.aggregates.supplier.commands;
using equipmentManagement.domain.aggregates.supplier.validations;
using equipmentManagement.domain.seedWork.aggregateHandler;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.aggregates.supplier.handlers
{
    public sealed class HandlerModifySupplier : AggregateHandler<Supplier>
    {
        private readonly ModifySupplierCommand data;
        private readonly ISupplierRepository repositorio;

        private HandlerModifySupplier(ModifySupplierCommand data, ISupplierRepository repositorio, INotification notification) : base(notification)
        {
            this.data = data;
            this.repositorio = repositorio;
        }
        public static HandlerModifySupplier New(ModifySupplierCommand data, ISupplierRepository repositorio, INotification notification)
            => new HandlerModifySupplier(data, repositorio, notification);

        protected override void execute(Supplier entity)
        {
            if (repositorio.CNPJHasAlreadyBeenNotifiedToAnotherSupplier(data.CNPJ, data.Id).Result)
                notification.Add(SupplierMessages.CNPJHasAlreadyBeenInformed);

            if (notification.HasError) return;

            entity.Modify(data, notification);
        }

    }
}
