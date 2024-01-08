using AutoMapper;
using equipmentManagement.domain.aggregates.product;
using equipmentManagement.infra.data.input.entityTypeConfiguration.models;

namespace equipmentManagement.infra.data.input.autoMapper
{
    public class SupplierModelToSupplier : Profile
    {
        public SupplierModelToSupplier()
            => CreateMap<SupplierModel, Supplier>();
    }
}
