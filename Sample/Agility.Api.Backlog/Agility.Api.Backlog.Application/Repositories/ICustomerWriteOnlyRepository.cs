using System.Threading.Tasks;

using Agility.Api.Backlog.Domain.Customers;

namespace Agility.Api.Backlog.Application.Repositories
{
    public interface ICustomerWriteOnlyRepository
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
    }
}
