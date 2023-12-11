using MediatR;

namespace Wep_1.Application.UseCases.Products.Commands
{
    public class UpdateProductCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
