using System;
using System.Collections.Generic;
using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<GetProductListQueryLookupModel>, IRequest<GetProductListQueryReturnModel>
    {
    }
}
