using MediatR;
using Microsoft.EntityFrameworkCore;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Products.Queries;
using Wep_1.Domain.Entities;

namespace Wep_1.Application.UseCases.Users.Handels
{
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand, List<Product>>
    {
        private readonly IApplicationContext _context;
        public GetAllProductsCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Products.AsNoTracking().ToListAsync();
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
