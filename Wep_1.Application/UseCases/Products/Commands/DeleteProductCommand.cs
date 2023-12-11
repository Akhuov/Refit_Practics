using MediatR;

namespace Wep_1.Application.UseCases.Products.Commands
{
    public class DeleteProductCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
