using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetProductBytId
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryLookupModel>
    {
        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(
            IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetProductByIdQueryLookupModel> Handle(GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _productService.GetProductByIdAsync(request.ProductId, cancellationToken);
        }
    }
}