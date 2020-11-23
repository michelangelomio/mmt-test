using FluentValidation;

namespace CleanArchitecture.Application.Product.Queries.GetFeaturedProductByProductId
{
    public class GetFeaturedProductByProductIdQueryValidation : AbstractValidator<GetFeaturedProductByProductIdQuery>
    {
        public GetFeaturedProductByProductIdQueryValidation()
        {
            RuleFor(x => x.ProductId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Product ID is not valid !");
        }
    }
}