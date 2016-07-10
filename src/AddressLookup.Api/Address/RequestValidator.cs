using FluentValidation;

namespace AddressLookup.Api.Address
{
    class RequestValidator : AbstractValidator<SearchRequest>
    {
        public RequestValidator()
        {
            RuleFor(request => request.Text).NotEmpty().WithMessage("You must specify a search query.");
            RuleFor(request => request.Count).NotEmpty().WithMessage("You must specify the maximum number of results.");
            RuleFor(request => request.Format).Equal("json").WithMessage("The format must be json, no other format is currently supported.");
        }
    }
}
