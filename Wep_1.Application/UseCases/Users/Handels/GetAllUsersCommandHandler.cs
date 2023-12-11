using MediatR;
using Microsoft.EntityFrameworkCore;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Users.Queries;
using Wep_1.Domain;

namespace Wep_1.Application.UseCases.Users.Handels
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, List<User>>
    {
        private readonly IApplicationContext _context;
        public GetAllUsersCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users != null)
                {

                    return users;
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
