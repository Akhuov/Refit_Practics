using MediatR;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Products.Commands;
using Wep_1.Domain.Entities;

namespace Wep_1.Application.UseCases.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IApplicationContext _context;
        public CreateProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Product
                {
                    Name = request.Name,
                    UserId = request.UserId,
                };

                var res = await _context.Products.AddAsync(product);

                return $" {res} \n ProductCreated Name = {product.Name}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
