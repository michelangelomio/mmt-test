using CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId;
using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<GetProductListQueryReturnModel>
    {
    }
}