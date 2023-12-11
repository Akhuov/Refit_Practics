using MediatR;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Users.Commands;
using Wep_1.Domain;

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

                var res = _context.Users.Add(newUser);

                return $" {res} \n UserCreated Name = {newUser.Name}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
