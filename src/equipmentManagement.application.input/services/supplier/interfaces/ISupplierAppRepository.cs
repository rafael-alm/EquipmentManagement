﻿using equipmentManagement.domain.aggregates.product;

namespace equipmentManagement.application.input.services.supplier.interfaces
{
    public interface ISupplierAppRepository
    {
        Task<Supplier> GetById(Guid id, CancellationToken cancellationToken);
        Task Add(Supplier entity, CancellationToken cancellationToken);
        void Update(Supplier entity);
    }
}
