using MediatR;
using Microsoft.EntityFrameworkCore;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Products.Commands;

namespace Wep_1.Application.UseCases.Products.Handels
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IApplicationContext _context;
        public UpdateUserCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (res != null)
                {
                    res.Name = request.Name;

                    _context.Products.Update(res);
                    var res2 = await _context.SaveChangesAsync(cancellationToken);
                    return $"{res2} \n Product Updated!! Name = {res.Name}";
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
