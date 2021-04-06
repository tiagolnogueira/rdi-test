using RDI.Test.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RDI.Test.Infra.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerCard(Guid id);
    }
}
