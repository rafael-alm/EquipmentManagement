using AutoMapper;
using equipmentManagement.application.input.services.company;
using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.domain.aggregates.company.validations;
using equipmentManagement.domain.seedWork.objectValues;
using equipmentManagement.domain.shared.seedWork.exceptions;
using equipmentManagement.infra.data.input.aggregates;
using equipmentManagement.tests.common;
using equipmentManagement.tests.common.fixture;
using FluentAssertions;
using inspecao.administrActive.dominio.modelos.empresa.repositorios;

namespace equipmentManagement.tests.integration.application.services.company
{
    public class DeactivateCompanyTest
    {
        private readonly CompanyFixture companyFixture;
        private readonly TestContextequipmentManagement dbContext;
        private readonly IMapper mapper;

        public DeactivateCompanyTest(TestContextequipmentManagement dbContext, IMapper mapper)
        {
            companyFixture = new CompanyFixture();
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [Fact(DisplayName = nameof(ValidDeactivateCompanyTest))]
        [Trait("Apliccation", "Service - Company")]
        public async void ValidDeactivateCompanyTest()
        {
            var repository = new CompanyRepository(dbContext, mapper);
            var readRepository = repository as ICompanyReadRepository;
            var createCompanyService = new CreateCompanyService(dbContext, repository) as ICreateCompanyService;
            var returnCompanyCreation = await createCompanyService.Execute(companyFixture.GetValidCreateCompanyCommandWithAllData(), CancellationToken.None);
            var companyBeforeUpdating = await readRepository.GetById(returnCompanyCreation.Id, CancellationToken.None);
            var inactivateCompanyService = new DeactivateCompanyService(dbContext, repository, readRepository) as IDeactivateCompanyService;

            await inactivateCompanyService.Execute(returnCompanyCreation.Id, CancellationToken.None);

            var companyAfterUpdating = await readRepository.GetById(returnCompanyCreation.Id, CancellationToken.None);

            companyAfterUpdating.Should().NotBeNull();
            companyAfterUpdating.Id.Should().Be(companyBeforeUpdating.Id);
            companyAfterUpdating.Name.Should().Be(companyBeforeUpdating.Name);
            companyAfterUpdating.RegisteredName.Should().Be(companyBeforeUpdating.RegisteredName);
            companyAfterUpdating.CNPJ.Should().Be(companyBeforeUpdating.CNPJ);
            companyAfterUpdating.TypeOfFacility.Should().Be(companyBeforeUpdating.TypeOfFacility);
            companyAfterUpdating.Active.Should().Be(false);
        }

        [Fact(DisplayName = nameof(ValidateCompanyDeactivationExcepitionTest))]
        [Trait("Apliccation", "Service - Company")]
        public async void ValidateCompanyDeactivationExcepitionTest()
        {
            var repository = new CompanyRepository(dbContext, mapper);
            var readRepository = new CompanyRepository(dbContext, mapper) as ICompanyReadRepository;
            var createCompanyService = new CreateCompanyService(dbContext, repository) as ICreateCompanyService;
            var returnCompanyCreation = await createCompanyService.Execute(companyFixture.GetValidCreateCompanyCommandWithAllData(), CancellationToken.None);
            var companyBeforeUpdating = await readRepository.GetById(returnCompanyCreation.Id, CancellationToken.None);
            var deactivateCompanyService = new DeactivateCompanyService(dbContext, repository, readRepository) as IDeactivateCompanyService;

            var task = async () => await deactivateCompanyService.Execute(companyBeforeUpdating.Id, CancellationToken.None);

            task.Should().ThrowAsync<EntityValidationException>().Result
                .Which.MessagesNotification.Should().Contain(CompanyMessages.CompanyAlreadyDeactivated);

            var companyAfterUpdating = await readRepository.GetById(returnCompanyCreation.Id, CancellationToken.None);

            companyAfterUpdating.Should().NotBeNull();
            companyAfterUpdating.Id.Should().Be(companyBeforeUpdating.Id);
            companyAfterUpdating.Name.Should().Be(companyBeforeUpdating.Name);
            companyAfterUpdating.RegisteredName.Should().Be(companyBeforeUpdating.RegisteredName);
            companyAfterUpdating.CNPJ.Should().Be(companyBeforeUpdating.CNPJ);
            companyAfterUpdating.TypeOfFacility.Should().Be(companyBeforeUpdating.TypeOfFacility);
            companyAfterUpdating.Active.Should().Be(false);
        }
    }
}
