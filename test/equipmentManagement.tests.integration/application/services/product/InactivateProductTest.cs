using AutoMapper;
using FluentAssertions;
using equipmentManagement.application.input.seedWork.repository;
using equipmentManagement.application.input.services.product;
using equipmentManagement.application.input.services.product.dto;
using equipmentManagement.application.input.services.product.interfaces;
using equipmentManagement.domain.aggregates.product.validations;
using equipmentManagement.domain.shared.enumeration;
using equipmentManagement.domain.shared.seedWork.exceptions;
using equipmentManagement.infra.data.input.aggregates;
using equipmentManagement.tests.common.fixture;
using equipmentManagement.tests.integration.common;

namespace equipmentManagement.tests.integration.application.services.product
{
    public class InactivateProductTest
    {
        private readonly ProductFixture productFixture;
        private readonly TestContextequipmentManagement dbContext;
        private readonly IMapper mapper;

        public InactivateProductTest(TestContextequipmentManagement dbContext, IMapper mapper)
        {
            productFixture = new ProductFixture();
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [Fact(DisplayName = nameof(ValidInactivateProductTest))]
        [Trait("Apliccation", "Service - Product")]
        public async void ValidInactivateProductTest()
        {
            IProductAppRepository repsitory = new ProductRepository(dbContext, mapper);
            ICreateProductService createProductService = new CreateProductService(dbContext, repsitory);

            var returnProductCreation = await createProductService.Execute(productFixture.GetValidCreateProductCommandWithAllData(), CancellationToken.None);

            var productCreated = await repsitory.GetById(returnProductCreation.Id, CancellationToken.None);

            IInactivateProductService inactivateProductService = new InactivateProductService(dbContext, repsitory);

            await inactivateProductService.Execute(returnProductCreation.Id, CancellationToken.None);

            var productNow = await repsitory.GetById(returnProductCreation.Id, CancellationToken.None);

            productNow.Should().NotBeNull();
            productNow.Id.Should().Be(productCreated.Id);
            productNow.Description.Should().Be(productCreated.Description);
            productNow.SupplierId.Should().Be(productCreated.SupplierId);
            productNow.ManufacturingDate.Should().Be(productCreated.ManufacturingDate);
            productNow.ExpirationDate.Should().Be(productCreated.ExpirationDate);
            productNow.Status.Should().Be(StatusEntityEnum.Inactive);
        }

        [Fact(DisplayName = nameof(InactivateExpectingEntityValidationException))]
        [Trait("Apliccation", "Service - Product")]
        public async void InactivateExpectingEntityValidationException()
        {
            IProductAppRepository repsitory = new ProductRepository(dbContext, mapper);

            ICreateProductService createProductService = new CreateProductService(dbContext, repsitory);
            var returnProductCreation = await createProductService.Execute(productFixture.GetValidCreateProductCommandWithAllData(), CancellationToken.None);
            var productCreated = await repsitory.GetById(returnProductCreation.Id, CancellationToken.None);

            IInactivateProductService inactivateProductService = new InactivateProductService(dbContext, repsitory);

            await inactivateProductService.Execute(productCreated.Id, CancellationToken.None);

            var productvvvvv = await repsitory.GetById(returnProductCreation.Id, CancellationToken.None);

            var task = async () => await inactivateProductService.Execute(productCreated.Id, CancellationToken.None);

            task.Should().ThrowAsync<EntityValidationException>().Result
                .Which.MessagesNotification.Should().Contain(ProductMessages.ProductIsAlreadyInactive);

            var productNow = await repsitory.GetById(returnProductCreation.Id, CancellationToken.None);

            productNow.Should().NotBeNull();
            productNow.Id.Should().Be(productCreated.Id);
            productNow.Description.Should().Be(productCreated.Description);
            productNow.SupplierId.Should().Be(productCreated.SupplierId);
            productNow.ManufacturingDate.Should().Be(productCreated.ManufacturingDate);
            productNow.ExpirationDate.Should().Be(productCreated.ExpirationDate);
            productNow.Status.Should().Be(StatusEntityEnum.Inactive);
        }
    }
}
