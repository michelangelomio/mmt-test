using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId
{
    public class GetProductListByCategoryIdReturnModel
    {
        public GetProductListByCategoryIdReturnModel()
        {
            Products = new List<GetProductListByCategoryIdQueryLookupModel>();
        }

        public List<GetProductListByCategoryIdQueryLookupModel> Products { get; set; }

    }
}
