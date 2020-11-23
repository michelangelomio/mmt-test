using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Category.Queries.GetCategoryList
{
    public class GetCategoryListReturnModel
    {
        public GetCategoryListReturnModel()
        {
            Categories = new List<GetCategoryListLookupModel>();
        }

        public List<GetCategoryListLookupModel> Categories { get; set; }

    }
}
