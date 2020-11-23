using FluentValidation;

namespace CleanArchitecture.Application.Category.Queries.GetCategory
{
    public class GetCategoryQueryValidation : AbstractValidator<GetCategoryQuery>
    {
        public GetCategoryQueryValidation()
        {
            RuleFor(x => x.CategoryId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Category ID is not valid !");
        }
    }
}