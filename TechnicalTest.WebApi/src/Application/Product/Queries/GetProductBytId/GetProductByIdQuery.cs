using MediatR;

namespace CleanArchitecture.Application.Product.Queries.GetProductBytId
{
    public class GetProductByIdQuery : IRequest<GetProductByIdQueryLookupModel>
    {
        public int ProductId { get; set; }
    }
}