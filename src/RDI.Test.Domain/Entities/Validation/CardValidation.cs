using FluentValidation;

namespace RDI.Test.Domain.Entities.Validation
{
    public class CardValidation : AbstractValidator<Card>
    {
        public CardValidation()
        {
            RuleFor(c => c.CardNumber)
                .Empty().WithMessage("The field {PropertyName} can't be empty.")
               .GreaterThan(0).WithMessage("The field {PropertyName} can be greater than 0.");

            RuleFor(c => c.CVV)
                .Empty().WithMessage("The field {PropertyName} can't be empty.")
               .GreaterThan(0).WithMessage("The field {PropertyName} can be greater than 0.");
        }
    }
}