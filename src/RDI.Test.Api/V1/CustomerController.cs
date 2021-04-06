using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDI.Test.Api.Controllers;
using RDI.Test.Api.Extensions;
using RDI.Test.Api.ViewModels;
using RDI.Test.Application.Interfaces;
using RDI.Test.Domain.Entities;
using RDI.Test.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace RDI.Test.Api.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/customers")]
    public class CustomersController : MainController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository,
                                      IMapper mapper,
                                      ICustomerService customerService,
                                      INotificator notificator,
                                      IUser user) : base(notificator, user)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _customerService = customerService;
        }

        [ClaimsAuthorize("Customer", "Get")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerViewModel>> GetById(Guid id)
        {
            var customer = await GetCustomerCard(id);

            if (customer == null) return NotFound();

            return customer;
        }

        [ClaimsAuthorize("Customer", "Add")]
        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> Adicionar(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _customerService.Add(_mapper.Map<Customer>(customerViewModel));

            return CustomResponse(customerViewModel);
        }

        private async Task<CustomerViewModel> GetCustomerCard(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetCustomerCard(id));
        }
    }
}
