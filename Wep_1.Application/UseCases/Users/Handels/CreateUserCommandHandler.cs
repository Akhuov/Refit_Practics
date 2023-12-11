using MediatR;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Users.Commands;
using Wep_1.Domain.Entities;

namespace Wep_1.Application.UseCases.Users.Handels
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IApplicationContext _context;
        public CreateUserCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = new User
                {
                    Name = request.Name,
                };

                var res = await _context.Users.AddAsync(newUser);

                return $" {res} \n UserCreated Name = {newUser.Name}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
