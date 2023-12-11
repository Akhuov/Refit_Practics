using MediatR;
using Wep_1.Domain.Entities;

namespace Wep_1.Application.UseCases.Products.Queries
{
    public class GetAllProductsCommand : IRequest<List<Product>>
    {
    }
}
