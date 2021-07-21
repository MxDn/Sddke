using System;
using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Results;

namespace Agility.Api.Backlog.Application.Queries
{
    public interface ICustomersQueries
    {
        Task<CustomerResult> GetCustomer(Guid id);
    }
}
