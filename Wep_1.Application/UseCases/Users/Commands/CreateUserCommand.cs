using MediatR;

namespace Wep_1.Application.UseCases.Users.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Name { get; set; }

    }
}
