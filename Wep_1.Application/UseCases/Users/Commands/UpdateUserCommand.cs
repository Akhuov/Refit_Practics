using MediatR;

namespace Wep_1.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : IRequest<string>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
