﻿using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.application.input.services.product;
using equipmentManagement.application.input.services.product.interfaces;
using equipmentManagement.domain.aggregates.product.commands;
using equipmentManagement.domain.aggregates.product.validations;
using equipmentManagement.domain.shared.enumeration;
using equipmentManagement.domain.shared.seedWork.exceptions;
using equipmentManagement.infra.data.input.aggregates;
using equipmentManagement.tests.common.fixture;
using equipmentManagement.tests.integration.common;

namespace equipmentManagement.tests.integration.application.services.product
{
    public class CreateProductTest
    {
        private readonly ProductFixture productFixture;
        private readonly TestContextequipmentManagement dbContext;
        private readonly IMapper mapper;

        public CreateProductTest(TestContextequipmentManagement context, IMapper mapper)
        {
            productFixture = new ProductFixture();
            this.dbContext = context;
            this.mapper = mapper;
        }

        [Fact(DisplayName = nameof(ValidCreationOfBasicData))]
        [Trait("Apliccation", "Service - Product")]
        public async void ValidCreationOfBasicData()
        {
            var dbContex = TestContextequipmentManagement.New();
            var validCreateProductCommand = productFixture.GetValidCreateProductCommandWithBasicData();
            IProductAppRepository repsitory = new ProductRepository(dbContex, mapper);
            ICreateProductService createProductService = new CreateProductService(dbContex, repsitory);

            var returnProductCreation = await createProductService.Execute(validCreateProductCommand, CancellationToken.None);

            returnProductCreation.Id.Should().NotBeEmpty();
            returnProductCreation.Id.Should().NotBe("00000000-0000-0000-0000-000000000000");

            var productNow = await repsitory.GetById(returnProductCreation.Id, CancellationToken.None);

            productNow.Should().NotBeNull();
            productNow.Id.Should().Be(returnProductCreation.Id);
            productNow.Description.Should().Be(validCreateProductCommand.Description);
            productNow.SupplierId.Should().Be(validCreateProductCommand.SupplierId);
            productNow.ManufacturingDate.Should().Be(validCreateProductCommand.ManufacturingDate);
            productNow.ExpirationDate.Should().Be(validCreateProductCommand.ExpirationDate);
            productNow.Status.Should().Be(StatusEntityEnum.Active);
        }

        [Fact(DisplayName = nameof(ValidCreationOfAllData))]
        [Trait("Apliccation", "Service - Product")]
        public async void ValidCreationOfAllData()
        {
            var validCreateProductCommand = productFixture.GetValidCreateProductCommandWithAllData();

            IProductAppRepository repsitory = new ProductRepository(dbContext, mapper);
            ICreateProductService createProductService = new CreateProductService(dbContext, repsitory);

            var returnProductCreation = await createProductService.Execute(validCreateProductCommand, CancellationToken.None);

            returnProductCreation.Id.Should().NotBeEmpty();
            returnProductCreation.Id.Should().NotBe("00000000-0000-0000-0000-000000000000");

            var productNow = await repsitory.GetById(returnProductCreation.Id, CancellationToken.None);

            productNow.Should().NotBeNull();
            productNow.Id.Should().Be(returnProductCreation.Id);
            productNow.Description.Should().Be(validCreateProductCommand.Description);
            productNow.SupplierId.Should().Be(validCreateProductCommand.SupplierId);
            productNow.ManufacturingDate.Should().Be(validCreateProductCommand.ManufacturingDate);
            productNow.ExpirationDate.Should().Be(validCreateProductCommand.ExpirationDate);
            productNow.Status.Should().Be(StatusEntityEnum.Active);
        }

        [Fact(DisplayName = nameof(CreationExpectingEntityValidationException))]
        [Trait("Apliccation", "Service - Product")]
        public void CreationExpectingEntityValidationException()
        {
            var dbContex = TestContextequipmentManagement.New();
            var repsitory = new ProductRepository(dbContex, mapper);
            ICreateProductService createProductService = new CreateProductService(dbContex, repsitory);

            var task = async () => await createProductService.Execute(new CreateProductCommand(), CancellationToken.None);

            task.Should().ThrowAsync<EntityValidationException>().Result
                .Which.MessagesNotification.Should().Contain(ProductMessages.DescriptionIsRequired);

            task = async () => await createProductService.Execute(productFixture.GetInvalidCreateProductCommandWithAllData(), CancellationToken.None);

            var messagens = new List<ProductMessages>()
            {
                ProductMessages.DescriptionMustHaveAMaximumOf250Characters,
                ProductMessages.ExpirationDateCannotBeLessThanTheManufacturingDate
            };

            task.Should().ThrowAsync<EntityValidationException>().Result
                .Which.MessagesNotification.Should().Contain(messagens);
        }
    }
}
