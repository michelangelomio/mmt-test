using MediatR;

namespace CleanArchitecture.Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdLookupModel>
    {
        public int CategoryId { get; set; }
    }
}