using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.infra.data.input;

namespace equipmentManagement.tests.integration.common
{
    public class TestContextequipmentManagement : ContextequipmentManagement, IDbContext
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
