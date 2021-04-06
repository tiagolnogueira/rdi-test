using FluentValidation;

namespace RDI.Test.Domain.Entities.Validation
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
        }
    }
}