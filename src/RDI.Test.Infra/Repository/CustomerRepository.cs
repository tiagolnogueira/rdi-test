using Microsoft.EntityFrameworkCore;
using RDI.Test.Domain.Entities;
using RDI.Test.Infra.Context;
using RDI.Test.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace RDI.Test.Infra.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetCustomerCard(Guid id)
        {
            return await Db.Customers.AsNoTracking()
                .Include(c => c.Card)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}