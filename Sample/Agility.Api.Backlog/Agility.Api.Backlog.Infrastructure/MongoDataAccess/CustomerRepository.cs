using System;
using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Repositories;
using Agility.Api.Backlog.Domain.Customers;

using MongoDB.Driver;

namespace Agility.Api.Backlog.Infrastructure.MongoDataAccess
{
    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly Context mongoContext;

        public CustomerRepository(Context mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task<Customer> Get(Guid customerId)
        {
            Customer customer = await mongoContext.Customers
                .Find(e => e.Id == customerId)
                .SingleOrDefaultAsync();

            return customer;
        }

        public async Task Add(Customer customer)
        {
            await mongoContext.Customers
                .InsertOneAsync(customer);
        }

        public async Task Update(Customer customer)
        {
            await mongoContext.Customers
                .ReplaceOneAsync(e => e.Id == customer.Id, customer);
        }
    }
}
