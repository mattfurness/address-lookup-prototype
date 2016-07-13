using FluentValidation;

namespace AddressLookup.Api.Addresses
{
    public class RequestValidator : AbstractValidator<SearchRequest>
    {
        public RequestValidator()
        {
            RuleFor(request => request.Text).NotEmpty().WithMessage("You must specify a search query.");
            RuleFor(request => request.Count).NotNull().GreaterThan(0).WithMessage("You must specify the maximum number of results tht is greater than 0.");
            RuleFor(request => request.Format).Equal("json").WithMessage("The format must be json, no other format is currently supported.");
        }
    }
}
