using equipmentManagement.api.input.Configurations;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.infra.data.input;
using equipmentManagement.tests.common;
using Microsoft.Extensions.DependencyInjection;

namespace equipmentManagement.tests.integration
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapperConfiguration();
            services.AddDbContext<TestContextequipmentManagement>();
            services.AddScoped<IDbContext, UnitOfWork>();
        }
    }
}
