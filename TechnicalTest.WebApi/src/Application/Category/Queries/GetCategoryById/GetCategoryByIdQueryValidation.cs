using CleanArchitecture.Application.Common.Interfaces.Services;
using FluentValidation;

namespace CleanArchitecture.Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidation : AbstractValidator<GetCategoryByIdQuery>
    {

        private readonly ICheckDbService _checkDbService;

        public GetCategoryByIdQueryValidation(
            ICheckDbService checkDbService)
        {
            _checkDbService = checkDbService;

            RuleFor(x => x.CategoryId)
                .NotNull()
                .GreaterThan(0)
                .MustAsync(checkDbService.CheckCategoryIdAsync)
                .WithMessage("Category ID is not valid!");
        }
    }
}