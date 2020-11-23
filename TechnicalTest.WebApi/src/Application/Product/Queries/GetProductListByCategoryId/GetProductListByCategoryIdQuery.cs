using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId
{
    public class GetProductListByCategoryIdQuery : IRequest<GetProductListByCategoryIdReturnModel>
    {
        public int SelectedCategoryId { get; set; }
    }
}