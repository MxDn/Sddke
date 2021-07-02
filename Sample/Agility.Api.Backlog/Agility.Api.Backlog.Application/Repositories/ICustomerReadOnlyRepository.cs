using System;
using System.Threading.Tasks;

using Agility.Api.Backlog.Domain.Customers;

namespace Agility.Api.Backlog.Application.Repositories
{
    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}
