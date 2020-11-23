using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetFeaturedProductByProductId
{
    public class GetFeaturedProductByProductIdQueryHandler : IRequestHandler<GetFeaturedProductByProductIdQuery, GetFeaturedProductByProductIdQueryLookupModel>
    {
        private readonly IProductService _productService;

        public GetFeaturedProductByProductIdQueryHandler(
            IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetFeaturedProductByProductIdQueryLookupModel> Handle(GetFeaturedProductByProductIdQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetFeaturedProductByProductIdAsync(request.ProductId, cancellationToken);
        }
    }
}