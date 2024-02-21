using AutoMapper;
using equipmentManagement.application.input.services.company;
using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.domain.aggregates.company.commands;
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
    public class CreateCompanyTest
    {
        private readonly CompanyFixture companyFixture;
        private readonly TestContextequipmentManagement dbContext;
        private readonly IMapper mapper;

        public CreateCompanyTest(TestContextequipmentManagement context, IMapper mapper)
        {
            companyFixture = new CompanyFixture();
            this.dbContext = context;
            this.mapper = mapper;
        }

        [Fact(DisplayName = nameof(ValidCreationOfAllData))]
        [Trait("Apliccation", "Service - Company")]
        public async void ValidCreationOfAllData()
        {
            var dbContex = TestContextequipmentManagement.New();
            var validCreateCompanyCommand = companyFixture.GetValidCreateCompanyCommandWithAllData();
            var repsitory = new CompanyRepository(dbContex, mapper);
            var companyReadRepository = repsitory as ICompanyReadRepository;

            ICreateCompanyService createCompanyService = new CreateCompanyService(dbContex, repsitory);

            var returnCompanyCreation = await createCompanyService.Execute(validCreateCompanyCommand, CancellationToken.None);

            returnCompanyCreation.Id.Should().NotBeEmpty();
            returnCompanyCreation.Id.Should().NotBe("00000000-0000-0000-0000-000000000000");

            var companyNow = await companyReadRepository.GetById(returnCompanyCreation.Id, CancellationToken.None);

            companyNow.Should().NotBeNull();
            companyNow.Id.Should().Be(returnCompanyCreation.Id);
            companyNow.Name.Should().Be(validCreateCompanyCommand.Name);
            companyNow.RegisteredName.Should().Be(validCreateCompanyCommand.RegisteredName);
            companyNow.TypeOfFacility.Should().Be(validCreateCompanyCommand.TypeOfFacility);
        }

        [Fact(DisplayName = nameof(CreationWithEntityValidationException))]
        [Trait("Apliccation", "Service - Company")]
        public void CreationWithEntityValidationException()
        {
            var dbContex = TestContextequipmentManagement.New();
            var repsitory = new CompanyRepository(dbContex, mapper);
            ICreateCompanyService createCompanyService = new CreateCompanyService(dbContex, repsitory);

            var task = async () => await createCompanyService.Execute(new CreateCompanyCommand(), CancellationToken.None);

            var messagensRequired = new List<CompanyMessages>()
            {
                CompanyMessages.NameIsRequired,
                CompanyMessages.RegisteredNameIsRequired,
                CompanyMessages.CnpjIsRequired,
                CompanyMessages.TypeOfFacilityDeveSerValida
            };

            task.Should().ThrowAsync<EntityValidationException>().Result
                .Which.MessagesNotification.Should().Contain(messagensRequired);
        }
    }
}
