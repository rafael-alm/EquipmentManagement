﻿using AutoMapper;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.application.input.services.product;
using equipmentManagement.application.input.services.product.dto;
using equipmentManagement.application.input.services.product.interfaces;
using equipmentManagement.domain.aggregates.product;
using equipmentManagement.domain.aggregates.product.commands;
using equipmentManagement.domain.aggregates.product.handlers;
using equipmentManagement.domain.shared.seedWork.notification;
using equipmentManagement.infra.data.input;
using equipmentManagement.infra.data.input.aggregates;

namespace equipmentManagement.tests.common.fixture
{
    [Collection(nameof(ProductFixture))]
    public sealed class ProductFixture : BaseFixture
    {
        public ProductFixture()
            : base()
        {
        }

        public string GetValidDescription()
        {
            var description = Faker.Commerce.ProductDescription();

            if (description.Length > 250)
                description = description[..250];

            return description;
        }

        public string GetInvalidDescription()
            => string.Join(null, Enumerable.Range(1, 251).Select(_ => "a").ToArray());

        public CreateProductCommand GetValidCreateProductCommandWithBasicData()
            => new CreateProductCommand { Description = GetValidDescription() };

        public CreateProductCommand GetValidCreateProductCommandWithAllData()
            => new CreateProductCommand
            {
                Description = GetValidDescription(),
                ManufacturingDate = DateOnly.FromDateTime(DateTime.Now),
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddYears(1)),
                SupplierId = Guid.NewGuid()
            };

        public ModifyProductCommand GetValidModifyProductCommandWithAllData(Guid id)
            => new ModifyProductCommand
            {
                Id = id,
                Description = GetValidDescription(),
                ManufacturingDate = DateOnly.FromDateTime(DateTime.Now),
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddYears(1)),
                SupplierId = Guid.NewGuid()
            };

        public CreateProductCommand GetInvalidCreateProductCommandWithAllData()
            => new CreateProductCommand
            {
                Description = GetInvalidDescription(),
                ManufacturingDate = DateOnly.FromDateTime(DateTime.Now),
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now),
                SupplierId = default
            };

        public ModifyProductCommand GetInvalidModifyProductCommandWithAllData(Guid id)
            => new ModifyProductCommand
            {
                Id = id,
                Description = GetInvalidDescription(),
                ManufacturingDate = DateOnly.FromDateTime(DateTime.Now),
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now),
                SupplierId = default
            };

        public Product GetValidProductWithAllData()
            => HandlerCreateProduct.New(GetValidCreateProductCommandWithAllData(), Notification.New()).Execute()!;

        public Product GetValidProductWithBasicData()
            => HandlerCreateProduct.New(GetValidCreateProductCommandWithBasicData(), Notification.New()).Execute()!;

        //public async Task<ReturnProductCreation> CreateProductInDBContext(IDbContext dbContex, IMapper mapper, CreateProductCommand validCreateProductCommand)
        //{
        //    var repsitory = new ProductRepository(dbContex, mapper);
        //    ICreateProductService createProductService = new CreateProductService(dbContex, repsitory);

        //    return await createProductService.Execute(validCreateProductCommand, CancellationToken.None);
        //}
    }
}
