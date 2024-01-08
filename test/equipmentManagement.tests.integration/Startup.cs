using Microsoft.Extensions.DependencyInjection;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.infra.data.input;
using equipmentManagement.infra.data.input.autoMapper;
using equipmentManagement.tests.integration.common;

namespace equipmentManagement.tests.integration
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductToProductModel));
            services.AddDbContext<TestContextequipmentManagement>();
            services.AddScoped<IDbContext, UnitOfWork>();
        }
    }
}
