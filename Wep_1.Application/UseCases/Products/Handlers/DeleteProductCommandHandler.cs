using MediatR;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Products.Commands;

namespace Wep_1.Application.UseCases.Products.Handels
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IApplicationContext _context;
        public DeleteProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = _context.Products.FirstOrDefault(x => x.Id == request.Id);
                if (res != null)
                {
                    _context.Products.Remove(res);
                    var res2 = await _context.SaveChangesAsync(cancellationToken);
                    return $"{res2} Product Deleted! Name = {res.Name}";
                }
                throw new Exception("Product NotFound!!");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
