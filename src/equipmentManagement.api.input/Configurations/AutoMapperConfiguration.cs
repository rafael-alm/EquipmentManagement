using equipmentManagement.infra.data.input.autoMapper;

namespace equipmentManagement.api.input.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
            => services.AddAutoMapper(typeof(ProductToProductModel), 
                                      typeof(ProductModelToProduct),
                                      typeof(SupplierModelToSupplier), 
                                      typeof(SupplierToSupplierModel));
    }
}
