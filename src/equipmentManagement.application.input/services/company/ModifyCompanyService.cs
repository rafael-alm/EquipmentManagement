using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.domain.aggregates.company.commands;
using equipmentManagement.domain.shared.seedWork.notification;
using inspecao.administrActive.dominio.modelos.empresa.repositorios;
using equipmentManagement.domain.seedWork.objectValues;

namespace equipmentManagement.application.input.services.company
{
    public sealed class ModifyCompanyService : IModifyCompanyService
    {
        private readonly IDbContext dbContext;
        private readonly ICompanyWriteRepository companyWriteRepository;
        private readonly ICompanyReadRepository companyReadRepository;

        public ModifyCompanyService(IDbContext dbContext, ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            this.dbContext = dbContext;
            this.companyWriteRepository = companyWriteRepository;
            this.companyReadRepository = companyReadRepository;
        }

        async Task IModifyCompanyService.Execute(ModifyCompanyCommand data, CancellationToken cancellationToken)
        {
            var notification = Notification.New();
            var company = await companyReadRepository.GetById(data.Id, cancellationToken);
            company.Modify(data, notification);

            //var handlerModifyProduct = HandlerModifyProduct.New(data, notification);

            //company.Handler(handlerModifyProduct);

            notification.ThrowExceptionIfError();

            companyWriteRepository.Update(company);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
