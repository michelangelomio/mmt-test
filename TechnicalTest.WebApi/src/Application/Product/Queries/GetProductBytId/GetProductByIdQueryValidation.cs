using CleanArchitecture.Application.Common.Interfaces.Services;
using FluentValidation;

namespace CleanArchitecture.Application.Product.Queries.GetProductBytId
{
    public class GetProductByIdQueryValidation : AbstractValidator<GetProductByIdQuery>
    {
        private readonly ICheckDbService _checkDbService;
        public GetProductByIdQueryValidation(
            ICheckDbService checkDbService)
        {
            _checkDbService = checkDbService;
            RuleFor(x => x.ProductId)
                .NotNull()
                .GreaterThan(0)
                .MustAsync(_checkDbService.CheckProductIdAsync)
                .WithMessage("Product ID is not valid !");
        }
    }
}