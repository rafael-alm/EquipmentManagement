using AutoMapper;
using equipmentManagement.domain.aggregates.product;
using equipmentManagement.infra.data.input.entityTypeConfiguration.models;

namespace equipmentManagement.infra.data.input.autoMapper
{
    public class ProductModelToProduct : Profile
    {
        public ProductModelToProduct()
            => CreateMap<ProductModel, Product>();
    }
}
