using MediatR;
using Microsoft.EntityFrameworkCore;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Users.Commands;

namespace Wep_1.Application.UseCases.Users.Handels
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IApplicationContext _context;
        public UpdateUserCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (res != null)
                {
                    res.Name = request.Name;

                    _context.Users.Update(res);
                    var res2 = await _context.SaveChangesAsync(cancellationToken);
                    return $"{res2} \n User Updated!! Name = {res.Name}";
                }
                throw new Exception("User NotFound!!");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
