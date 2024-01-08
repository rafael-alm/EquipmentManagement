﻿using Microsoft.EntityFrameworkCore;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.infra.data.input.entityTypeConfiguration;
using equipmentManagement.infra.data.input.entityTypeConfiguration.models;

namespace equipmentManagement.infra.data.input
{
    public class ContextequipmentManagement : DbContext, IAsyncDisposable
    {
        public bool HasTransaction { get; private set; }

        public ContextequipmentManagement(DbContextOptions options) : base(options)
        {
            HasTransaction = false;
            this.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SupplierConfiguration().Configure(modelBuilder.Entity<SupplierModel>());
            new ProductConfiguration().Configure(modelBuilder.Entity<ProductModel>());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await base.SaveChangesAsync(cancellationToken);

        public void DiscardChanges()
            => base.ChangeTracker.Clear();

        public void BeginTransaction()
        {
            Database?.BeginTransaction();
            HasTransaction = true;
        }

        public override ValueTask DisposeAsync()
        {
            var retorno = base.DisposeAsync();
            HasTransaction = false;

            return retorno;
        }

        public async Task Commit(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            Database?.CurrentTransaction?.CommitAsync(cancellationToken);
            HasTransaction = false;
        }

        public Task Rollback(CancellationToken cancellationToken = default)
        {
            DiscardChanges();
            Database?.CurrentTransaction?.RollbackAsync(cancellationToken);
            HasTransaction = false;

            return Task.CompletedTask;
        }
    }
}
