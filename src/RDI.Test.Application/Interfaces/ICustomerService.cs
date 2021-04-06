using RDI.Test.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RDI.Test.Application.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        Task<bool> Add(Customer customer);
    }
}