using RDI.Test.Application.Interfaces;
using RDI.Test.Domain.Entities;
using RDI.Test.Domain.Entities.Validation;
using RDI.Test.Infra.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RDI.Test.Application.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository,
                                 INotificator notificator) : base(notificator)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Add(Customer customer)
        {
            if (!ExecutarValidacao(new CustomerValidation(), customer)
                || !ExecutarValidacao(new CardValidation(), customer.Card)) return false;

            if (_customerRepository.Find(f => f.Card.CardNumber == customer.Card.CardNumber).Result.Any())
            {
                Notify("This card number already exists.");
                return false;
            }

            await _customerRepository.Add(customer);
            return true;
        }


        public void Dispose()
        {
            _customerRepository?.Dispose();
        }
    }
}