using equipmentManagement.application.input.services.company.dto;
using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.domain.shared.seedWork.notification;
using equipmentManagement.domain.aggregates.company;
using equipmentManagement.domain.aggregates.company.commands;

namespace equipmentManagement.application.input.services.company
{
    public sealed class CreateCompanyService : ICreateCompanyService
    {
        private readonly IDbContext dbContext;
        private readonly ICompanyWriteRepository companyAppRepository;

        public CreateCompanyService(IDbContext dbContext, ICompanyWriteRepository companyAppRepository)
        {
            this.dbContext = dbContext;
            this.companyAppRepository = companyAppRepository;
        }

        async Task<ReturnCompanyCreation> ICreateCompanyService.Execute(CreateCompanyCommand data, CancellationToken cancellationToken)
        {
            var notification = Notification.New();
            //var handlerCreateProduct = HandlerCreateProduct.New(data, notification);
            //var company = handlerCreateProduct.Execute();
            var company = Company.Create(data, notification);

            notification.ThrowExceptionIfError();

            await companyAppRepository.Add(company!, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);
            //await dbContext.Commit();

            return new ReturnCompanyCreation(company!.Id.Value);
        }
    }
}
