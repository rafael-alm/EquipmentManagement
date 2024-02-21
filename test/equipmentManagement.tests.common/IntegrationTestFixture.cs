using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.infra.data.input;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace equipmentManagement.tests.common
{
    public class TestContextequipmentManagement : ContextEquipmentManagement, IDbContext
    {
        public static TestContextequipmentManagement New()
            => new TestContextequipmentManagement();

        public TestContextequipmentManagement()
            : base(new DbContextOptionsBuilder<TestContextequipmentManagement>()
                .UseInMemoryDatabase("TestContextequipmentManagement")
                .UseInternalServiceProvider(new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .EnableSensitiveDataLogging()
                .Options)
        {
        }
    }
}
