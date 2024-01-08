using equipmentManagement.application.input.services.product.interfaces;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.domain.aggregates.product.commands;
using equipmentManagement.domain.aggregates.product.handlers;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.application.input.services.product
{
    public sealed class ModifyProductService : IModifyProductService
    {
        private readonly IDbContext dbContext;
        private readonly IProductAppRepository productAppRepository;

        public ModifyProductService(IDbContext dbContext, IProductAppRepository productAppRepository)
        {
            this.dbContext = dbContext;
            this.productAppRepository = productAppRepository;
        }

        async Task IModifyProductService.Execute(ModifyProductCommand data, CancellationToken cancellationToken)
        {
            var notification = Notification.New();
            var product = await productAppRepository.GetById(data.Id, cancellationToken);
            var handlerModifyProduct = HandlerModifyProduct.New(data, notification);

            product.Handler(handlerModifyProduct);

            notification.ThrowExceptionIfError();

            productAppRepository.Update(product);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
