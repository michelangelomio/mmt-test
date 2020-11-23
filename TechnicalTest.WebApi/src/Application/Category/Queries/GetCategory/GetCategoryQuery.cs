using MediatR;

namespace CleanArchitecture.Application.Category.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<GetCategoryLookupModel>
    {
        public int CategoryId { get; set; }
    }
}