using FluentValidation;

namespace Application.Customer.Queries.GetCustomerById;

public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}
