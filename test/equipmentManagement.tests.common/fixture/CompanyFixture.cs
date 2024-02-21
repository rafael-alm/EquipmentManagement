using Bogus.Extensions.Brazil;
using equipmentManagement.domain.aggregates.company.commands;
using equipmentManagement.domain.shared.enumeration;

namespace equipmentManagement.tests.common.fixture
{
    [Collection(nameof(CompanyFixture))]
    public sealed class CompanyFixture : BaseFixture
    {

        public CompanyFixture()
            : base()
        {
        }

        public string GetValidName()
        {
            var description = Faker.Company.CompanyName();

            if (description.Length > 250)
                description = description[..250];

            return description;
        }

        public string GetInvalidName()
            => string.Join(null, Enumerable.Range(1, 251).Select(_ => "a").ToArray());

        public CreateCompanyCommand GetValidCreateCompanyCommandWithAllData()
            => new CreateCompanyCommand
            {
                Name = GetValidName(),
                RegisteredName = GetValidName(),
                CNPJ = Faker.Company.Cnpj(false),
                TypeOfFacility = TypeOfFacility.Industrial.Id
            };

        public ModifyCompanyCommand GetValidModifyCompanyCommandWithAllData(string id)
            => new ModifyCompanyCommand
            {
                Id = id,
                Name = GetValidName(),
                RegisteredName = GetValidName(),
                CNPJ = Faker.Company.Cnpj(false),
                TypeOfFacility = TypeOfFacility.Industrial.Id
            };

        public CreateCompanyCommand GetCreateCompanyCommandWithAllInvalidData()
            => new CreateCompanyCommand
            {
                Name = GetInvalidName(),
                RegisteredName = GetInvalidName(),
                CNPJ = "11111111111",
                TypeOfFacility = 5
            };

        public ModifyCompanyCommand GetModifyCompanyCommandWithAllInvalidData(string id)
            => new ModifyCompanyCommand
            {
                Id = id,
                Name = GetInvalidName(),
                RegisteredName = GetInvalidName(),
                CNPJ = "11111111111",
                TypeOfFacility = 5
            };
    }
}
