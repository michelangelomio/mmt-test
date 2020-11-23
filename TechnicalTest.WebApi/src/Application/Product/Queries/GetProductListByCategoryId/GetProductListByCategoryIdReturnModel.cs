using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId
{
    public class GetProductListByCategoryIdReturnModel
    {
        public GetProductListByCategoryIdReturnModel()
        {
            FeaturedProducts = new List<GetProductListByCategoryIdQueryLookupModel>();
        }

        public List<GetProductListByCategoryIdQueryLookupModel> FeaturedProducts { get; set; }

    }
}
