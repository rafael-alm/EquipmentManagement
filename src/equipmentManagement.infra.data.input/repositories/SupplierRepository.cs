using AutoMapper;
using Microsoft.EntityFrameworkCore;
using equipmentManagement.application.input.services.supplier.interfaces;
using equipmentManagement.domain.aggregates.product;
using equipmentManagement.domain.aggregates.supplier;
using equipmentManagement.domain.objectValues;
using equipmentManagement.domain.shared.seedWork.exceptions;
using equipmentManagement.infra.data.input.entityTypeConfiguration.models;

namespace equipmentManagement.infra.data.input.aggregates
{
    public sealed class SupplierRepository : ISupplierRepository, ISupplierAppRepository
    {
        private readonly ContextequipmentManagement context;
        private readonly DbSet<SupplierModel> suppliers;
        private readonly IMapper mapper;

        public SupplierRepository(ContextequipmentManagement context, IMapper mapper)
        {
            this.context = context;
            this.suppliers = context.Set<SupplierModel>();
            this.mapper = mapper;
        }

        async Task<bool> ISupplierRepository.CNPJHasAlreadyBeenNotifiedToAnotherSupplier(CNPJ cnpj, Guid? exceptSupplierWithId)
            => await suppliers.AnyAsync(x => x.CNPJ.Number == cnpj.Number && x.Id != exceptSupplierWithId);

        async Task ISupplierAppRepository.Add(Supplier entity, CancellationToken cancellationToken)
            => await suppliers.AddAsync(mapper.Map<SupplierModel>(entity), cancellationToken);

        async Task<Supplier> ISupplierAppRepository.GetById(Guid id, CancellationToken cancellationToken)
        {
            var supplierModel = await suppliers.FirstOrDefaultAsync(x => x.Id == id);

            NotFoundException.ThrowIfNull(supplierModel);

            return mapper.Map<Supplier>(supplierModel);
        }

        void ISupplierAppRepository.Update(Supplier entity)
        {
            var supplierModel = suppliers.Single(x => x.Id == entity.Id);
            supplierModel = mapper.Map(entity, supplierModel);
            suppliers.Update(supplierModel);

            context.Entry(supplierModel)
                   .Property(nameof(supplierModel.Code))
                   .IsModified = false;
        }
    }
}
