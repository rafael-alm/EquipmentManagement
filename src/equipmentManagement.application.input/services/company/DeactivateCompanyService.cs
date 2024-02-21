using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.domain.seedWork.objectValues;
//using equipmentManagement.domain.aggregates.company.handlers;
using equipmentManagement.domain.shared.seedWork.notification;
using inspecao.administrActive.dominio.modelos.empresa.repositorios;

namespace equipmentManagement.application.input.services.company
{
    public sealed class DeactivateCompanyService : IDeactivateCompanyService
    {
        private readonly IDbContext dbContext;
        private readonly ICompanyWriteRepository companyWriteRepository;
        private readonly ICompanyReadRepository companyReadRepository;

        public DeactivateCompanyService(IDbContext dbContext, ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            this.dbContext = dbContext;
            this.companyWriteRepository = companyWriteRepository;
            this.companyReadRepository = companyReadRepository;
        }

        async Task IDeactivateCompanyService.Execute(EntityIdentity id, CancellationToken cancellationToken)
        {
            var notification = Notification.New();
            var company = await companyReadRepository.GetById(id, cancellationToken);
            company.Deactivate(notification);

            //var handlerDisableProduct = HandlerDisableProduct.New(notification);

            //company.Handler(handlerDisableProduct);

            notification.ThrowExceptionIfError();

            companyWriteRepository.Update(company);

            await dbContext.SaveChangesAsync(cancellationToken);
            await dbContext.Commit();
        }
    }
}
