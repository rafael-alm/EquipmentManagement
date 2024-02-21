using AutoMapper;
using equipmentManagement.infra.data.input.autoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace equipmentManagement.api.input.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
            => services.AddAutoMapper(typeof(CompanyToCompanyModel),
                                      typeof(CompanyModelToCompany));
    }
}
