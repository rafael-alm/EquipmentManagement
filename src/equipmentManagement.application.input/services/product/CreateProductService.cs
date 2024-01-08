using equipmentManagement.application.input.services.product.dto;
using equipmentManagement.application.input.services.product.interfaces;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.domain.aggregates.product.commands;
using equipmentManagement.domain.aggregates.product.handlers;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.application.input.services.product
{
    public sealed class CreateProductService : ICreateProductService
    {
        private readonly IDbContext dbContext;
        private readonly IProductAppRepository productAppRepository;

        public CreateProductService(IDbContext dbContext, IProductAppRepository productAppRepository)
        {
            this.dbContext = dbContext;
            this.productAppRepository = productAppRepository;
        }

        async Task<ReturnProductCreation> ICreateProductService.Execute(CreateProductCommand data, CancellationToken cancellationToken)
        {
            var notification = Notification.New();
            var handlerCreateProduct = HandlerCreateProduct.New(data, notification);
            var product = handlerCreateProduct.Execute();

            notification.ThrowExceptionIfError();

            await productAppRepository.Add(product!, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);
            await dbContext.Commit();

            return new ReturnProductCreation(product!.Id);
        }
    }
}
