using MediatR;

namespace Wep_1.Application.UseCases.Products.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
