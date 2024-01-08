using equipmentManagement.domain.aggregates.product;
using equipmentManagement.domain.aggregates.supplier.commands;
using equipmentManagement.domain.aggregates.supplier.validations;
using equipmentManagement.domain.seedWork.aggregateHandler;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.aggregates.supplier.handlers
{
    public sealed class HandlerCreateSupplier : HandlerCreateAggregate<Supplier>
    {
        private readonly CreateSupplierCommand data;
        private readonly ISupplierRepository readRepositorio;

        private HandlerCreateSupplier(CreateSupplierCommand data, ISupplierRepository readRepositorio, INotification notification) : base(notification)
        {
            this.data = data;
            this.readRepositorio = readRepositorio;
        }
        public static HandlerCreateSupplier New(CreateSupplierCommand data, ISupplierRepository repositorioDeLeitura, INotification notification)
            => new HandlerCreateSupplier(data, repositorioDeLeitura, notification);

        protected override Supplier? execute()
        {
            if (readRepositorio.CNPJHasAlreadyBeenNotifiedToAnotherSupplier(data.CNPJ).Result)
                notification.Add(SupplierMessages.CNPJHasAlreadyBeenInformed);

            if (notification.HasError) return default;

            return Supplier.Create(data, notification);
        }

    }
}
