using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetFeaturedProductByProductId
{
    public class GetFeaturedProductByProductIdQuery : IRequest<GetFeaturedProductByProductIdQueryLookupModel>
    {
        public int ProductId { get; set; }
    }
}