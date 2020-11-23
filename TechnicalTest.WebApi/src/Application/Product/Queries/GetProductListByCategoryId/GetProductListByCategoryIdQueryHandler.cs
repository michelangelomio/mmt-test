using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId
{
    public class GetProductListByCategoryIdQueryHandler : IRequestHandler<GetProductListByCategoryIdQuery,
        GetProductListByCategoryIdReturnModel>
    {
        private readonly IProductService _productService;

        public GetProductListByCategoryIdQueryHandler(
            IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetProductListByCategoryIdReturnModel> Handle(GetProductListByCategoryIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _productService.GetAllFeaturedProductsByCategoryIdAsync(request.SelectedCategoryId, cancellationToken);
        }
    }
}