using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Product.Queries.GetProductList
{
    public class GetProductListQueryLookupModel
    {
        public int ProductId { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}
