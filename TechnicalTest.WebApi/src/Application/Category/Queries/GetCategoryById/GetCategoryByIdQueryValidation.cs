using FluentValidation;

namespace CleanArchitecture.Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidation : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidation()
        {
            RuleFor(x => x.CategoryId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Category ID is not valid !");
        }
    }
}