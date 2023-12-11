using MediatR;
using Wep_1.Domain.Entities;

namespace Wep_1.Application.UseCases.Products.Queries
{
    public class GetByIdProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
