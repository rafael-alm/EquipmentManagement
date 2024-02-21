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
    public class ModifyCompanyTest
    {
        private readonly CompanyFixture companyFixture;
        private readonly IMapper mapper;

        public ModifyCompanyTest(IMapper mapper)
        {
            companyFixture = new CompanyFixture();
            this.mapper = mapper;
        }

        [Fact(DisplayName = nameof(ValidModification))]
        [Trait("Apliccation", "Service - Company")]
        public async void ValidModification()
        {
            var dbContex = TestContextequipmentManagement.New();
            var repository = new CompanyRepository(dbContex, mapper);
            var readRepsitory = repository as ICompanyReadRepository;
            var createCompanyService = new CreateCompanyService(dbContex, repository) as ICreateCompanyService;
            var returnCompanyCreation = await createCompanyService.Execute(companyFixture.GetValidCreateCompanyCommandWithAllData(), CancellationToken.None);
            var modifyCompanyCommand = companyFixture.GetValidModifyCompanyCommandWithAllData(returnCompanyCreation.Id);
            var companyBeforeUpdating = await readRepsitory.GetById(returnCompanyCreation.Id, CancellationToken.None);
            var modifyCompanyService = new ModifyCompanyService(dbContex, repository, repository) as IModifyCompanyService;

            await modifyCompanyService.Execute(modifyCompanyCommand, CancellationToken.None);

            var companyAfterUpdating = await readRepsitory.GetById(returnCompanyCreation.Id, CancellationToken.None);

            companyAfterUpdating.Should().NotBeNull();
            companyAfterUpdating.Id.Should().Be(modifyCompanyCommand.Id);
            companyAfterUpdating.Name.Should().Be(modifyCompanyCommand.Name);
            companyAfterUpdating.RegisteredName.Should().Be(modifyCompanyCommand.RegisteredName);
            companyAfterUpdating.CNPJ.Should().Be(modifyCompanyCommand.CNPJ);
            companyAfterUpdating.TypeOfFacility.Id.Should().Be(modifyCompanyCommand.TypeOfFacility);
            companyAfterUpdating.Active.Should().Be(companyBeforeUpdating.Active);
        }

        [Fact(DisplayName = nameof(ModificationExpectingEntityValidationException))]
        [Trait("Apliccation", "Service - Company")]
        public async void ModificationExpectingEntityValidationException()
        {
            var dbContex = TestContextequipmentManagement.New();
            var repository = new CompanyRepository(dbContex, mapper);
            var readRepository = repository as ICompanyReadRepository;
            var createCompanyService = new CreateCompanyService(dbContex, repository) as ICreateCompanyService;
            var returnCompanyCreation = await createCompanyService.Execute(companyFixture.GetValidCreateCompanyCommandWithAllData(), CancellationToken.None);
            var companyCreated = await readRepository.GetById(returnCompanyCreation.Id, CancellationToken.None);
            var companyBeforeUpdating = await readRepository.GetById(returnCompanyCreation.Id, CancellationToken.None);
            var modifyCompanyService = new ModifyCompanyService(dbContex, repository, readRepository) as IModifyCompanyService;

            var task = async () => await modifyCompanyService.Execute(new ModifyCompanyCommand { Id = returnCompanyCreation.Id }, CancellationToken.None);

            var messagensRequired = new List<CompanyMessages>()
            {
                CompanyMessages.NameIsRequired,
                CompanyMessages.RegisteredNameIsRequired,
                CompanyMessages.CnpjIsRequired,
                CompanyMessages.TypeOfFacilityDeveSerValida
            };

            task.Should().ThrowAsync<EntityValidationException>().Result
                .Which.MessagesNotification.Should().Contain(messagensRequired);

            //var invalidModifyCompanyCommand = companyFixture.GetModifyCompanyCommandWithAllInvalidData(returnCompanyCreation.Id);
            //task = async () => await modifyCompanyService.Execute(invalidModifyCompanyCommand, CancellationToken.None);

            //var messagens = new List<CompanyMessages>()
            //{
            //    CompanyMessages.DescriptionMustHaveAMaximumOf250Characters,
            //    CompanyMessages.ExpirationDateCannotBeLessThanTheManufacturingDate
            //};

            //task.Should().ThrowAsync<EntityValidationException>().Result
            //    .Which.MessagesNotification.Should().Contain(messagens);

            var companyAfterUpdating = await readRepository.GetById(returnCompanyCreation.Id, CancellationToken.None);

            companyAfterUpdating.Should().NotBeNull();
            companyAfterUpdating.Id.Should().Be(companyBeforeUpdating.Id);
            companyAfterUpdating.Name.Should().Be(companyBeforeUpdating.Name);
            companyAfterUpdating.RegisteredName.Should().Be(companyBeforeUpdating.RegisteredName);
            companyAfterUpdating.CNPJ.Should().Be(companyBeforeUpdating.CNPJ);
            companyAfterUpdating.TypeOfFacility.Should().Be(companyBeforeUpdating.TypeOfFacility);
            companyAfterUpdating.Active.Should().Be(companyBeforeUpdating.Active);
        }
    }
}
