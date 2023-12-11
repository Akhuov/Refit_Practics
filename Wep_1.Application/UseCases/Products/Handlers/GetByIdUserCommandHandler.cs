using MediatR;
using Microsoft.EntityFrameworkCore;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Products.Queries;
using Wep_1.Domain.Entities;

namespace Wep_1.Application.UseCases.Products.Handels
{
    public class GetByIdProductCommandHandler : IRequestHandler<GetByIdProductCommand, Product>
    {
        private readonly IApplicationContext _context;
        public GetByIdProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetByIdProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
                if (res != null)
                {

                    return res;
                }
                throw new Exception("Users not Found!!");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
