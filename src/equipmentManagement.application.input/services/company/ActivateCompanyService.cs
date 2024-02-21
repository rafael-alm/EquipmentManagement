using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.domain.shared.seedWork.notification;
using inspecao.administrActive.dominio.modelos.empresa.repositorios;
using equipmentManagement.domain.seedWork.objectValues;

namespace equipmentManagement.application.input.services.company
{
    public sealed class ActivateCompanyService : IActivateCompanyService
    {
        private readonly IDbContext dbContext;
        private readonly ICompanyWriteRepository companyWriteRepository;
        private readonly ICompanyReadRepository companyReadRepository;

        public ActivateCompanyService(IDbContext dbContext, ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            this.dbContext = dbContext;
            this.companyWriteRepository = companyWriteRepository;
            this.companyReadRepository = companyReadRepository;
        }

        async Task IActivateCompanyService.Execute(EntityIdentity id, CancellationToken cancellationToken)
        {
            var notification = Notification.New();
            var company = await companyReadRepository.GetById(id, cancellationToken);
            company.Activate(notification);

            notification.ThrowExceptionIfError();

            companyWriteRepository.Update(company);

            await dbContext.SaveChangesAsync(cancellationToken);
            await dbContext.Commit();
        }
    }
}
