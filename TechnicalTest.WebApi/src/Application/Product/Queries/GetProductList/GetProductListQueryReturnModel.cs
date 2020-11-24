using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Product.Queries.GetProductList
{
    public class GetProductListQueryReturnModel
    {
        public GetProductListQueryReturnModel()
        {
            Products = new List<GetProductListQueryLookupModel>();
        }

        public List<GetProductListQueryLookupModel> Products { get; set; }
    }
}
