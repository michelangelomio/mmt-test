using FluentValidation;

namespace CleanArchitecture.Application.Product.Queries.GetProductBytId
{
    public class GetProductByIdQueryValidation : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidation()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Product ID is not valid !");
        }
    }
}