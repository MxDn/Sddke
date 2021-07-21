// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using Agility.Application.Backlog.Commands.AddBacklogItem;
using Agility.Application.Backlog.Commands.CreateProduct;
using Agility.Application.Backlog.Queries.RetrieveProduct;
using Agility.BootStrap;

using Xunit;

namespace Agility.Backlog.Test
{
    /// <summary>
    /// The unit test1.
    /// </summary>
    public class UnitTest1
    {
        [Fact]
        public void GivenMyProductAsProductNameWhenCreateProductThenProductNameSHouldBeMyProduct()
        {
        }

        /// <summary>
        /// The test1.
        /// </summary>
        [Fact]
        public void CreateProduct()
        {
            var command = new CreateProductCommand()
            {
                ProductName = "MyProduct"
            };
            Application.Backlog.ApplicationBusDispatcher dispatcher = StartUp.Initialise();
            CreateProductCommandResponse responseCreateProductCommand = dispatcher.Handle<CreateProductCommand, CreateProductCommandResponse>(command);
            var query = new RetrieveProductByIdQuery() { ProductId = responseCreateProductCommand.ProductId };
            RetrieveProductQueryResponse responseRetrieveProductQuery = dispatcher.Handle<RetrieveProductQuery, RetrieveProductQueryResponse>(query);
            Assert.Equal("MyProduct", responseRetrieveProductQuery.Product.Name);
            Assert.NotNull(responseRetrieveProductQuery.Product.BackLog);
        }
        [Fact]
        public void AddBackLogItem()
        {
            Application.Backlog.ApplicationBusDispatcher dispatcher = StartUp.Initialise();
            var command = new CreateProductCommand()
            {
                ProductName = "MyProduct"
            };
            CreateProductCommandResponse responseCreateProductCommand = dispatcher.Handle<CreateProductCommand, CreateProductCommandResponse>(command);

            var addBacklogItemCommand = new AddBacklogItemCommand()
            {
                Name = "MyBacklogItemName",
                Description = "MyBacklogItem Description",
                ProductId = responseCreateProductCommand.ProductId
            };
            AddBacklogItemResponse AddBacklogItemResponse = dispatcher.Handle<AddBacklogItemCommand, AddBacklogItemResponse>(addBacklogItemCommand);
            Assert.NotNull(AddBacklogItemResponse.BacklogItemId);
            var query = new RetrieveProductByIdQuery() { ProductId = responseCreateProductCommand.ProductId };
            RetrieveProductQueryResponse responseRetrieveProductQuery = dispatcher.Handle<RetrieveProductQuery, RetrieveProductQueryResponse>(query);
            Assert.Equal(1, responseRetrieveProductQuery.Product.BackLog.BackLogItems.Count);
        }
    }
}
