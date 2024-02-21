using equipmentManagement.domain.aggregates.company;
using equipmentManagement.domain.aggregates.company.commands;
using equipmentManagement.domain.aggregates.company.validations;
using equipmentManagement.domain.shared.enumeration;
using equipmentManagement.domain.shared.seedWork.notification;
using equipmentManagement.tests.common.fixture;
using FluentAssertions;

namespace equipmentManagement.tests.unit.domain.aggregates.company
{
    [Collection(nameof(CompanyFixture))]
    public class CompanyTest
    {
        private readonly CompanyFixture companyFixture;

        public CompanyTest()
        {
            companyFixture = new CompanyFixture();
        }

        [Fact(DisplayName = nameof(ValidCreationOfAllData))]
        [Trait("Domain", "Aggregates - Company")]
        public void ValidCreationOfAllData()
        {
            var notification = Notification.New();
            var validCreateCompanyCommand = companyFixture.GetValidCreateCompanyCommandWithAllData();
            var company = Company.Create(validCreateCompanyCommand, notification);

            company.Should().NotBeNull();
            company.Id.Value.Should().NotBeEmpty();
            company.Id.Should().NotBe("00000000-0000-0000-0000-000000000000");
            company.Name.Should().Be(validCreateCompanyCommand.Name);
            company.RegisteredName.Should().Be(validCreateCompanyCommand.RegisteredName);
            company.TypeOfFacility.Should().Be(validCreateCompanyCommand.TypeOfFacility);
            company.CNPJ.Should().Be(validCreateCompanyCommand.CNPJ);
            company.Active.Should().BeTrue();

            notification.HasError.Should().BeFalse();
        }

        //[Theory(DisplayName = nameof(CreationWithMandatoryDescriptionError))]
        //[Trait("Domain", "Aggregates - Company")]
        //[InlineData("")]
        //[InlineData(null)]
        //[InlineData("   ")]
        //public void CreationWithMandatoryDescriptionError(string description)
        //{
        //    var notification = Notification.New();
        //    var createCompanyCommand = new CreateCompanyCommand { Description = description };
        //    var company = HandlerCreateCompany.New(createCompanyCommand, notification)
        //                                      .Execute();

        //    company.Should().BeNull();
        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.DescriptionIsRequired);
        //}

        //[Fact(DisplayName = nameof(CreationWithDescriptioErrorGreaterThan250Characters))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void CreationWithDescriptioErrorGreaterThan250Characters()
        //{
        //    var invalidDescription = companyFixture.GetInvalidName();
        //    var notification = Notification.New();
        //    var createCompanyCommand = new CreateCompanyCommand { Description = invalidDescription };
        //    var company = HandlerCreateCompany.New(createCompanyCommand, notification)
        //                                      .Execute();

        //    company.Should().BeNull();
        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.DescriptionMustHaveAMaximumOf250Characters);
        //}

        //[Fact(DisplayName = nameof(CreationWithAnErrorOfExpirationDateLessThanToTheManufacturingDate))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void CreationWithAnErrorOfExpirationDateLessThanToTheManufacturingDate()
        //{
        //    var dateNow = DateOnly.FromDateTime(DateTime.Now);
        //    var notification = Notification.New();
        //    var createCompanyCommand = new CreateCompanyCommand
        //    {
        //        Description = companyFixture.GetValidName(),
        //        ManufacturingDate = dateNow,
        //        ExpirationDate = dateNow.AddDays(-1)
        //    };

        //    var company = HandlerCreateCompany.New(createCompanyCommand, notification)
        //                                      .Execute();

        //    company.Should().BeNull();
        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.ExpirationDateCannotBeLessThanTheManufacturingDate);
        //}

        //[Fact(DisplayName = nameof(CreationWithAnErrorOfExpirationDateEqualThanToTheManufacturingDate))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void CreationWithAnErrorOfExpirationDateEqualThanToTheManufacturingDate()
        //{
        //    var dateNow = DateOnly.FromDateTime(DateTime.Now);
        //    var notification = Notification.New();
        //    var createCompanyCommand = new CreateCompanyCommand
        //    {
        //        Description = companyFixture.GetValidName(),
        //        ManufacturingDate = dateNow,
        //        ExpirationDate = dateNow
        //    };

        //    var company = HandlerCreateCompany.New(createCompanyCommand, notification)
        //                                      .Execute();

        //    company.Should().BeNull();
        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.ExpirationDateCannotBeLessThanTheManufacturingDate);
        //}

        //[Fact(DisplayName = nameof(ValidModificationOfAllData))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void ValidModificationOfAllData()
        //{
        //    var notification = Notification.New();
        //    var companyValid = companyFixture.GetValidCompanyWithBasicData();
        //    var validModifyCompanyCommand = companyFixture.GetValidModifyCompanyCommandWithAllData(companyValid.Id);
        //    var handlerModify = HandlerModifyCompany.New(validModifyCompanyCommand, notification);

        //    companyValid.Handler(handlerModify);

        //    companyValid.Id.Should().Be(validModifyCompanyCommand.Id);
        //    companyValid.Description.Should().Be(validModifyCompanyCommand.Description);
        //    companyValid.ExpirationDate.Should().Be(validModifyCompanyCommand.ExpirationDate);
        //    companyValid.ManufacturingDate.Should().Be(validModifyCompanyCommand.ManufacturingDate);
        //    companyValid.SupplierId.Should().Be(validModifyCompanyCommand.SupplierId);
        //    companyValid.Code.Should().Be(0);
        //    companyValid.Status.Should().Be(StatusEntityEnum.Active);

        //    notification.HasError.Should().BeFalse();
        //}

        //[Theory(DisplayName = nameof(ModificationWithMandatoryDescriptionError))]
        //[Trait("Domain", "Aggregates - Company")]
        //[InlineData("")]
        //[InlineData(null)]
        //[InlineData("   ")]
        //public void ModificationWithMandatoryDescriptionError(string invalidDescription)
        //{
        //    var notification = Notification.New();
        //    var companyValid = companyFixture.GetValidCompanyWithBasicData();
        //    var modifyCompanyCommand = new ModifyCompanyCommand { Id = companyValid.Id, Description = invalidDescription };
        //    var handlerModify = HandlerModifyCompany.New(modifyCompanyCommand, notification);

        //    companyValid.Handler(handlerModify);

        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.DescriptionIsRequired);
        //}

        //[Fact(DisplayName = nameof(ModificationWithDescriptioErrorGreaterThan250Characters))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void ModificationWithDescriptioErrorGreaterThan250Characters()
        //{
        //    var invalidDescription = companyFixture.GetInvalidName();
        //    var notification = Notification.New();
        //    var companyValid = companyFixture.GetValidCompanyWithBasicData();
        //    var modifyCompanyCommand = new ModifyCompanyCommand { Id = companyValid.Id, Description = invalidDescription };
        //    var handlerModify = HandlerModifyCompany.New(modifyCompanyCommand, notification);

        //    companyValid.Handler(handlerModify);

        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.DescriptionMustHaveAMaximumOf250Characters);
        //}

        //[Fact(DisplayName = nameof(ModificationWithAnErrorOfExpirationDateLessThanToTheManufacturingDate))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void ModificationWithAnErrorOfExpirationDateLessThanToTheManufacturingDate()
        //{
        //    var dateNow = DateOnly.FromDateTime(DateTime.Now);

        //    var notification = Notification.New();
        //    var companyValid = companyFixture.GetValidCompanyWithBasicData();
        //    var modifyCompanyCommand = new ModifyCompanyCommand
        //    {
        //        Id = companyValid.Id,
        //        Description = companyFixture.GetValidName(),
        //        ManufacturingDate = dateNow,
        //        ExpirationDate = dateNow.AddDays(-1)
        //    };
        //    var handlerModify = HandlerModifyCompany.New(modifyCompanyCommand, notification);

        //    companyValid.Handler(handlerModify);

        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.ExpirationDateCannotBeLessThanTheManufacturingDate);
        //}

        //[Fact(DisplayName = nameof(ModificationWithAnErrorOfExpirationDateEqualThanToTheManufacturingDate))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void ModificationWithAnErrorOfExpirationDateEqualThanToTheManufacturingDate()
        //{
        //    var dateNow = DateOnly.FromDateTime(DateTime.Now);

        //    var notification = Notification.New();
        //    var companyValid = companyFixture.GetValidCompanyWithBasicData();
        //    var modifyCompanyCommand = new ModifyCompanyCommand
        //    {
        //        Id = companyValid.Id,
        //        Description = companyFixture.GetValidName(),
        //        ManufacturingDate = dateNow,
        //        ExpirationDate = dateNow
        //    };
        //    var handlerModify = HandlerModifyCompany.New(modifyCompanyCommand, notification);

        //    companyValid.Handler(handlerModify);

        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.ExpirationDateCannotBeLessThanTheManufacturingDate);
        //}

        //[Fact(DisplayName = nameof(ValidateDeactivate))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void ValidateDeactivate()
        //{
        //    var notification = Notification.New();
        //    var companyValid = companyFixture.GetValidCompanyWithBasicData();
        //    var handlerDisable = HandlerDisableCompany.New(notification);

        //    companyValid.Handler(handlerDisable);

        //    companyValid.Status.Should().Be(StatusEntityEnum.Inactive);
        //    notification.HasError.Should().BeFalse();
        //    notification.Errors.Count.Should().Be(0);
        //}

        //[Fact(DisplayName = nameof(InvalidInactivation))]
        //[Trait("Domain", "Aggregates - Company")]
        //public void InvalidInactivation()
        //{
        //    var notification = Notification.New();
        //    var companyValid = companyFixture.GetValidCompanyWithBasicData();
        //    var handlerDisable = HandlerDisableCompany.New(notification);

        //    companyValid.Handler(handlerDisable, handlerDisable);

        //    notification.HasError.Should().BeTrue();
        //    notification.Errors.Count.Should().Be(1);
        //    notification.Errors.Single().Should().Be(CompanyMessages.CompanyIsAlreadyInactive);
        //}
    }
}
