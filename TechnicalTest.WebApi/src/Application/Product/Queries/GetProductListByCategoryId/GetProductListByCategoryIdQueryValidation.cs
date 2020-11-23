using FluentValidation;

namespace CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId
{
    public class GetProductListByCategoryIdQueryValidation : AbstractValidator<GetProductListByCategoryIdQuery>
    {
        public GetProductListByCategoryIdQueryValidation()
        {
            RuleFor(x => x.SelectedCategoryId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Selected category is not valid. Please select valid category.");
        }
    }
}