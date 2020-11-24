using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, GetProductListQueryReturnModel>
    {
        private readonly IProductService _productService;

        public GetProductListQueryHandler(
            IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetProductListQueryReturnModel> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProductsAsync(cancellationToken);
        }
    }
}
