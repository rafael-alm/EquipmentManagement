using AutoMapper;
using equipmentManagement.domain.aggregates.product;
using equipmentManagement.infra.data.input.entityTypeConfiguration.models;

namespace equipmentManagement.infra.data.input.autoMapper
{
    public class ProductToProductModel : Profile
    {
        public ProductToProductModel()
            => CreateMap<Product, ProductModel>();
    }
}
