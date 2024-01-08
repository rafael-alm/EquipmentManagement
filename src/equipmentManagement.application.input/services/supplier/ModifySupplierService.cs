using equipmentManagement.application.input.services.supplier.interfaces;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.domain.aggregates.supplier;
using equipmentManagement.domain.aggregates.supplier.commands;
using equipmentManagement.domain.aggregates.supplier.handlers;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.application.input.services.supplier
{
    public sealed class ModifySupplierService : IModifySupplierService
    {
        private readonly IDbContext dbContext;
        private readonly ISupplierAppRepository supplierAppRepository;
        private readonly ISupplierRepository supplierRepository;

        public ModifySupplierService(IDbContext dbContext, ISupplierAppRepository supplierAppRepository, ISupplierRepository supplierRepository)
        {
            this.dbContext = dbContext;
            this.supplierAppRepository = supplierAppRepository;
            this.supplierRepository = supplierRepository;
        }

        async Task IModifySupplierService.Execute(ModifySupplierCommand data, CancellationToken cancellationToken)
        {
            var notification = Notification.New();
            var supplier = await supplierAppRepository.GetById(data.Id, cancellationToken);
            var handlerModifySupplier = HandlerModifySupplier.New(data, supplierRepository, notification);

            supplier.Handler(handlerModifySupplier);

            notification.ThrowExceptionIfError();

            supplierAppRepository.Update(supplier);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
